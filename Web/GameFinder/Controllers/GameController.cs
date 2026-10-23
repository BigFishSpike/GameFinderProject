namespace GameFinder.Controllers
{
    using GameFinder.Data.Models.Enums;
    using GameFinder.Services.DTOs;
    using GameFinder.Services.Interfaces;
    using GameFinder.ViewModels.Game;
    using GameFinder.ViewModels.Genre;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using static GameFinder.Common.EntityValidation.ApplicationConstants;

    public class GameController : BaseController
    {
        private readonly IGameService gameService;
        private readonly IGenreService genreService;
        private readonly IUserFavouriteService userFavouriteService;

        public GameController(IGameService gameService, IGenreService genreService, IUserFavouriteService userFavouriteService)
        {
            this.gameService = gameService;
            this.genreService = genreService;
            this.userFavouriteService = userFavouriteService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> List()
        {
            IEnumerable<GameDto> games = await gameService.GetGamesList(EntitiesPerPage);

            IEnumerable<GameListViewModel> gameListViewModels = games
                .Select(g => new GameListViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                    GenreName = g.GenreName,
                })
                .ToList();
            
            string? userId = GetUserId();

            if (userId != null)
            {
                IEnumerable<GameDto> favourites = await userFavouriteService.GetUserFavouritesAsync(userId);

                HashSet<int> favouriteGameIds = favourites
                    .Select(g => g.Id)
                    .ToHashSet();

                foreach (GameListViewModel game in gameListViewModels)
                {
                    game.IsFavourite = favouriteGameIds.Contains(game.Id);
                }
            }

            return View(gameListViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute]int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                TempData["ErrorMessage"] = "Invalid game ID. Please select a game.";

                return RedirectToAction(nameof(List));
            }

            GameDetailsDto? gameDetailsDto = await gameService
                .GetGameDetails(id.Value);

            if (gameDetailsDto == null)
            {
                TempData["ErrorMessage"] = "Game not found. Please select another game.";
                
                return RedirectToAction(nameof(List));
            }

            string? userId = GetUserId();

            bool isOwner = !string.IsNullOrWhiteSpace(userId)
                && gameDetailsDto.CreatedByUserId == userId;

            GameDetailsViewModel gameDetailsViewModel = new GameDetailsViewModel()
            {
                Id = gameDetailsDto.Id,
                Name = gameDetailsDto.Name,
                Description = gameDetailsDto.Description,
                Difficulties = gameDetailsDto.Difficulties,
                PlayerOptions = gameDetailsDto.PlayerOptions,
                Modes = gameDetailsDto.Modes,
                ImageUrl = gameDetailsDto.ImageUrl,
                ReleaseDate = gameDetailsDto.ReleaseDate,
                IsOwner = isOwner,
            };


            return View(gameDetailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Search()
        {
            GameSearchViewModel gameModel = new GameSearchViewModel();

            IEnumerable<GenreDto> genres = await genreService.GenresGetList();

            gameModel.Genres = await GetGenres();

            return View(gameModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(GameSearchViewModel gameModel)
        {
            if (!ModelState.IsValid)
            {
                gameModel.Genres = await GetGenres();

                return View(gameModel);
            }

            gameModel.Searched = true;

            GameFindDto userRequests = new GameFindDto
            {
                Genre = gameModel.Genre,
                Mode = gameModel.Mode,
                PlayerOptions = gameModel.PlayerOption,
                Difficulty = gameModel.Difficulty,
            };

            IEnumerable<GameDto> gameDtos = await gameService.FindGames(userRequests);

            gameModel.Games = gameDtos
                .Select(g => new GameListViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                    ShowGenre = false,
                })
                .Take(EntitiesPerPage)
                .ToList();
            
            string? userId = GetUserId();

            if (userId != null)
            {
                IEnumerable<GameDto> favourites = await userFavouriteService.GetUserFavouritesAsync(userId);

                HashSet<int> favouriteGameIds = favourites
                    .Select(g => g.Id)
                    .ToHashSet();

                foreach (GameListViewModel game in gameModel.Games)
                {
                    game.IsFavourite = favouriteGameIds.Contains(game.Id);
                }

            }

            IEnumerable<GenreDto> genreDtos = await genreService.GenresGetList();

            gameModel.Genres = await GetGenres();


            return View(gameModel);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            GameAddViewModel model = new GameAddViewModel();

            model.Genres = await GetGenres();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(GameAddViewModel model)
        {
            model.Genres = await GetGenres();

            if (!model.Genres.Any(g => g.Id == model.GenreId))
            {
                ModelState.AddModelError(nameof(model.GenreId), "Please select a valid genre.");
            }

            if (model.Difficulties.Any(d => !Enum.IsDefined(typeof(Difficulty), d)))
            {
                ModelState.AddModelError(nameof(model.Difficulties), "One or more selected difficulties are invalid.");
            }

            if (model.PlayerOptions.Any(po => !Enum.IsDefined(typeof(PlayerOption), po)))
            {
                ModelState.AddModelError(nameof(model.PlayerOptions), "One or more selected player options are invalid.");
            }

            if (model.Modes.Any(m => !Enum.IsDefined(typeof(Mode), m)))
            {
                ModelState.AddModelError(nameof(model.Modes), "One or more selected game modes are invalid.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string? userId = GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Challenge();
            }

            GameAddDto gameDto = new GameAddDto
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                ReleaseDate = model.ReleaseDate,
                GenreId = model.GenreId,
                CreatedByUser = userId,

                Difficulties = model.Difficulties
                .Select(d => (Difficulty)d)
                .Distinct()
                .ToList(),

                PlayerOptions = model.PlayerOptions
                .Select(p => (PlayerOption)p)
                .Distinct()
                .ToList(),

                Modes = model.Modes
                .Select(m => (Mode)m)
                .Distinct()
                .ToList()
            };

            int gameId = await gameService.AddGame(gameDto);

            return RedirectToAction(nameof(Details), new { id = gameId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute] int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                TempData["ErrorMessage"] = "Invalid game ID. Please select a game.";

                return RedirectToAction(nameof(List));
            }

            GameDetailsDto? game = await gameService.GetGameDetails(id.Value);

            if (game == null)
            {
                TempData["ErrorMessage"] = "No game was found with this ID. Please select another game.";

                return RedirectToAction(nameof(List));
            }

            string? userId = GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Challenge();
            }

            if (game.CreatedByUserId != userId)
            {
                TempData["ErrorMessage"] = "Sorry, you don't have permission to edit this game.";

                return RedirectToAction(nameof(List));
            }

            GameEditViewModel model = new GameEditViewModel
            {
                Id = game.Id,
                Name = game.Name,
                Description = game.Description,
                ImageUrl = game.ImageUrl,
                ReleaseDate = game.ReleaseDate,
                GenreId = game.GenreId,

                Difficulties = game.Difficulties
                .Select(difficulty => (int)difficulty)
                .ToList(),

                PlayerOptions = game.PlayerOptions
                .Select(playerOption => (int)playerOption)
                .ToList(),

                Modes = game.Modes
                .Select(mode => (int)mode)
                .ToList(),

                Genres = await GetGenres()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromRoute] int? id, GameEditViewModel model)
        {
            if (!id.HasValue || id.Value <= 0 || id.Value != model.Id)
            {
                ModelState.AddModelError(string.Empty, "The game ID is invalid.");

                model.Genres = await GetGenres();

                return View(model);
            }

            model.Genres = await GetGenres();

            bool genreExists = model.Genres.Any(g => g.Id == model.GenreId);

            if (!genreExists)
            {
                ModelState.AddModelError(nameof(model.GenreId), "Please select a valid genre.");
            }

            foreach (int difficulty in model.Difficulties)
            {
                if (!Enum.IsDefined(typeof(Difficulty), difficulty))
                {
                    ModelState.AddModelError(nameof(model.Difficulties), "Invalid difficulty selected.");
                    break;
                }
            }

            foreach (int mode in model.Modes)
            {
                if (!Enum.IsDefined(typeof(Mode), mode))
                {
                    ModelState.AddModelError(nameof(model.Modes), "Invalid game mode selected.");
                    break;
                }
            }

            foreach (int playerOption in model.PlayerOptions)
            {
                if (!Enum.IsDefined(typeof(PlayerOption), playerOption))
                {
                    ModelState.AddModelError(nameof(model.PlayerOptions), "Invalid player option selected.");
                    break;
                }
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            GameUpdateDto updateGameDto = new GameUpdateDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                ReleaseDate = model.ReleaseDate,
                GenreId = model.GenreId,
                Difficulties = model.Difficulties
                    .Select(difficulty => (Difficulty)difficulty)
                    .ToList(),
                Modes = model.Modes
                    .Select(mode => (Mode)mode)
                    .ToList(),
                PlayerOptions = model.PlayerOptions
                    .Select(playerOption => (PlayerOption)playerOption)
                    .ToList()
            };

            string? userId = GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Challenge();
            }

            bool updated = await gameService.UpdateGame(updateGameDto, userId);

            if (!updated)
            {
                TempData["ErrorMessage"] = "The game could not be found. Please try again.";
                return RedirectToAction(nameof(List));
            }

            return RedirectToAction(nameof(Details), new { id = model.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                TempData["ErrorMessage"] = "Invalid ID entered. Please try again.";
                return RedirectToAction(nameof(List));
            }

            GameDetailsDto? game = await gameService.GetGameDetails(id.Value);

            if (game == null)
            {
                TempData["ErrorMessage"] = "The game could not be found. Please try again.";
                return RedirectToAction(nameof(List));
            }

            string? userId = GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Challenge();
            }

            if (game.CreatedByUserId != userId)
            {
                TempData["ErrorMessage"] = "Sorry, you don't have permission to delete this game.";
                return RedirectToAction(nameof(List));
            }

            GameDeleteViewModel model = new GameDeleteViewModel
            {
                Id = game.Id,
                Name = game.Name,
                ImageUrl = game.ImageUrl,
            };
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed([FromForm] int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "Invalid game ID.";
                return RedirectToAction(nameof(List));
            }

            string? userId = GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
            {
                return Challenge();
            }

            bool deleted = await gameService.DeleteGame(id, userId);

            if (!deleted)
            {
                TempData["ErrorMessage"] = "Action unsuccessful; game may not exist, or you may not have permission to delete it.";
                return RedirectToAction(nameof(List));
            }

            TempData["SuccessMessage"] = "Game deleted successfully!";
            return RedirectToAction(nameof(List));
        }


        private async Task<List<GenreListViewModel>> GetGenres()
        {
            IEnumerable<GenreDto> genres = await genreService.GenresGetList();

            return genres.Select(g => new GenreListViewModel
            {
                Id = g.Id,
                Name = g.Name,
            })
                .ToList();
        }

    }
}
