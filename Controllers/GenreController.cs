namespace GameFinder.Controllers
{
    using static Common.ApplicationConstants;
    using GameFinder.Data;
    using GameFinder.ViewModels.Game;
    using Microsoft.AspNetCore.Mvc;
    using GameFinder.Data.Models;
    using GameFinder.ViewModels.Genre;

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
                })
                .Take(EntitiesPerPage)
                .ToArray();

            return View(genreListViewModels);
        }
    }
}
