namespace GameFinder.Controllers
{
    using GameFinder.Services.DTOs;
    using GameFinder.Services.Interfaces;
    using GameFinder.ViewModels.Game;
    using GameFinder.ViewModels.Genre;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class GenreController : BaseController
    {
        private readonly IGenreService genreService;
        private readonly IUserFavouriteService userFavouriteService;

        public GenreController(IGenreService genreService, IUserFavouriteService userFavouriteService)
        {
            this.genreService = genreService;
            this.userFavouriteService = userFavouriteService;
        }

        [HttpGet]
        public async Task <IActionResult> List()
        {
            IEnumerable<GenreDto> genres = await genreService
                .GenresGetList();

            IEnumerable<GenreListViewModel> genreListViewModels = genres
                .Select(g => new GenreListViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                });

            return View(genreListViewModels);
        }

        [HttpGet]
        public async Task <IActionResult> Details([FromRoute]int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                TempData["ErrorMessage"] = "Invalid genre ID. Please select a genre.";
                
                return RedirectToAction(nameof(List));
            }
            
            GenreDetailsDto? genreDetailsDto = await genreService
                .GenreGetDetails(id.Value);           

            if (genreDetailsDto == null)
            {
                TempData["ErrorMessage"] = "Genre not found. Please select another genre."; 
                
                return RedirectToAction(nameof(List));

            }
            string? userId = GetUserId();

            bool isOwner = !string.IsNullOrWhiteSpace(userId) && genreDetailsDto.CreatedByUserId == userId;

            HashSet<int> favouriteGameIds = new HashSet<int>();

            if (userId != null)
            {
                IEnumerable<GameDto> favourites = await userFavouriteService.GetUserFavouritesAsync(userId);

                favouriteGameIds = favourites
                    .Select(g => g.Id)
                    .ToHashSet();
            }

            GenreDetailsViewModel? genreDetailsViewModel = new GenreDetailsViewModel
            {
                Id = genreDetailsDto.Id,
                Name = genreDetailsDto.Name,
                Description = genreDetailsDto.Description,
                ImageUrl = genreDetailsDto.ImageUrl,
                IsOwner = isOwner,

                Games = genreDetailsDto.Games
                .Select(gm => new GameListViewModel
                {
                    Id = gm.Id,
                    Name = gm.Name,
                    ImageUrl = gm.ImageUrl,
                    ShowGenre = false,
                    IsFavourite = favouriteGameIds.Contains(gm.Id),
                })
                .ToList()
            };

            return View(genreDetailsViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(GenreAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string? userId = GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Challenge();
            }

            GenreAddDto genreDto = new GenreAddDto
            {
                Name = model.Name.Trim(),
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                CreatedByUserId = userId,
            };

            int genreId = await genreService.GenreAdd(genreDto);

            if (genreId == 0)
            {
                ModelState.AddModelError(nameof(model.Name), "A genre with this name already exists.");

                return View(model);
            }

            TempData["SuccessMessage"] = "Genre created successfully!";

            return RedirectToAction(nameof(List));

        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                TempData["ErrorMessage"] = "Invalid genre ID. Please try again.";
                return RedirectToAction(nameof(List));
            }

            GenreDetailsDto? genre = await genreService.GenreGetDetails(id.Value);

            if (genre == null)
            {
                TempData["ErrorMessage"] = "Sorry, but the requested genre could not be found.";
                return RedirectToAction(nameof(List));
            }

            string? userId = GetUserId();

            if (string.IsNullOrWhiteSpace(userId) || genre.CreatedByUserId != userId)
            {
                TempData["ErrorMessage"] = "You don't have permission to edit this genre.";
                return RedirectToAction(nameof(List));
            }

            GenreEditViewModel model = new GenreEditViewModel()
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
                ImageUrl = genre.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GenreEditViewModel model)
        {
            string? userId = GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Challenge();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            GenreEditDto genreDto = new GenreEditDto()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl
            };

            bool edited = await genreService.GenreEdit(genreDto, userId);

            if (!edited)
            {
                TempData["ErrorMessage"] = "The genre could not be edited. Please check for duplicate genre.";

                return RedirectToAction(nameof(List));
            }

            TempData["SuccessMessage"] = "Genre edited successfully.";

            return RedirectToAction(nameof(Details), new { id = model.Id });

        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                TempData["ErrorMessage"] = "Invalid genre ID; please enter a valid ID.";

                return RedirectToAction(nameof(List));
            }

            GenreDetailsDto? genre = await genreService
                .GenreGetDetails(id.Value);

            if (genre == null)
            {
                TempData["ErrorMessage"] = "Genre not found; please enter a valid Genre.";
                return RedirectToAction(nameof(List));
            }

            string? userId = GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Challenge();
            }

            if (genre.CreatedByUserId != userId)
            {
                TempData["ErrorMessage"] = "Sorry, you don't have permission to delete this genre.";

                return RedirectToAction(nameof(List));
            }

            IEnumerable<GenreDto> genres = await genreService.GenresGetList();

            GenreDeleteViewModel model = new GenreDeleteViewModel
            {
                Id = genre.Id,
                Name = genre.Name,
                ReplacementGenre = genres
                .Where(g => g.Id != genre.Id)
                .Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                })
                .ToList()

            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(GenreDeleteViewModel model)
        {
            string? userId = GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Challenge();
            }

            if (!ModelState.IsValid)
            {
                await PopulateReplacementGenre(model);

                foreach (var error in ModelState)
                {
                    foreach (var entry in error.Value.Errors)
                    {
                        Console.WriteLine(
                            $"Field: {error.Key}, Error: {entry.ErrorMessage}");
                    }
                }

                return View(model);
            }

            bool deleted = await genreService.GenreDelete(model.Id, userId, model.ReplacementGenreId);

            if (!deleted)
            {
                TempData["ErrorMessage"] = "Sorry, action denied; either the genre doesn't exist or you do not have permission to delete it.";

                return RedirectToAction(nameof(List));
            }

            TempData["SuccessMessage"] = "Genre deleted successfully!";

            return RedirectToAction(nameof(List));
        }

        private async Task PopulateReplacementGenre(GenreDeleteViewModel model)
        {
            IEnumerable<GenreDto> genres = await genreService.GenresGetList();

            model.ReplacementGenre = genres
                .Where(g => g.Id != model.Id)
                .Select(g => new SelectListItem
                {
                    Value = g.Id.ToString(),
                    Text = g.Name
                })
                .ToList();
        }
    }
}
