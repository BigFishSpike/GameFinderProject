namespace GameFinder.Controllers
{
    using GameFinder.Services.DTOs;
    using GameFinder.Services.Interfaces;
    using GameFinder.ViewModels.Game;
    using GameFinder.ViewModels.Genre;
    using Microsoft.AspNetCore.Mvc;

    public class GenreController : BaseController
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            this.genreService = genreService;
        }

        [HttpGet]
        public async Task <IActionResult> List()
        {
            IEnumerable<GenreDto> genres = await genreService
                .GetGenresList();

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
                return BadRequest("Incorrect value entered. Please try again.");
            }
            
            GenreDetailsDto? genreDetailsDto = await genreService
                .GetGenreDetails(id.Value);           

            if (genreDetailsDto == null)
            {
                return NotFound("Genre not found. Please pick a different genre.");

            }

            GenreDetailsViewModel? genreDetailsViewModel = new GenreDetailsViewModel
            {
                Id = genreDetailsDto.Id,
                Name = genreDetailsDto.Name,
                Description = genreDetailsDto.Description,
                ImageUrl = genreDetailsDto.ImageUrl,


                Games = genreDetailsDto.Games
                .Select(gm => new GameListViewModel
                {
                    Id = gm.Id,
                    Name = gm.Name,
                    ImageUrl = gm.ImageUrl,
                    ShowGenre = false,
                })
                .ToList()
            };

            return View(genreDetailsViewModel);
        }

       
    }
}
