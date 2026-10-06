namespace GameFinder.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using GameFinder.ViewModels.Game;
    using static Common.ApplicationConstants;
    using GameFinder.Data.Models;
    using GameFinder.Data;

    public class GameController : Controller
    {
        private readonly GameFinderDbContext dbContext;

        private readonly ILogger<GameController> logger;

        public GameController(ILogger<GameController> logger, GameFinderDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        [HttpGet]
        public IActionResult List()
        {
            IEnumerable<GameListViewModel> gameListViewModels = dbContext.Games
                .OrderBy(g => g.GenreId)
                .ThenBy(g => g.Name)
                .Select(g => new GameListViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                    GenreName = g.Genre.Name,

                })
                .Take(EntitiesPerPage)
                .ToArray();

            return View(gameListViewModels);
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
    }
}
