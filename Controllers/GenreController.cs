namespace GameFinder.Controllers
{
    using GameFinder.Data;
    using GameFinder.ViewModels.Genre;
    using GameFinder.ViewModels.Game;
    using Microsoft.AspNetCore.Mvc;
    using static Common.ApplicationConstants;

    public class GenreController : Controller
    {
        private readonly GameFinderDbContext dbContext;

        private readonly ILogger<GenreController> logger;

        public GenreController(ILogger<GenreController> logger, GameFinderDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult List()
        {
            IEnumerable<GenreListViewModel> genreListViewModels = dbContext.Genres
                .OrderBy(g => g.Id)
                .ThenBy(g => g.Name)
                .Select(g => new GenreListViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                })
                .Take(EntitiesPerPage)
                .ToArray();

            return View(genreListViewModels);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return BadRequest("Incorrect value entered. Please try again.");
            }

            GenreDetailsViewModel? genreDetailsViewModel = dbContext.Genres
                .Where(g => g.Id == id.Value)
                .Select(g => new GenreDetailsViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,

                    Games = dbContext.Games
                    .OrderBy(ga => ga.Difficulty)
                    .ThenBy(ga => ga.Name)
                    .Where(ga => ga.GenreId == g.Id)
                    .Select(ga => new GameListViewModel
                    {
                        Id = ga.Id,
                        Name = ga.Name,
                        ImageUrl = ga.ImageUrl,
                    })
                    .ToList()
                })
                .SingleOrDefault();            

            if (genreDetailsViewModel == null)
            {
                return NotFound("Genre not found. Please pick a different genre.");

            }

            return View(genreDetailsViewModel);
        }
    }
}
