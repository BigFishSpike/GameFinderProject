namespace GameFinder.Controllers
{
    using GameFinder.Data;
    using GameFinder.ViewModels.Game;
    using GameFinder.ViewModels.Genre;
    using Microsoft.AspNetCore.Mvc;
    using static Common.ApplicationConstants;

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

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return BadRequest("Incorrect value entered. Please try again.");
            }

            GameDetailsViewModel? gameDetailsViewModel = dbContext.Games
                .Where(g => g.Id == id.Value)
                .Select(g => new GameDetailsViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    Description = g.Description,
                    Difficulty = g.Difficulty,
                    PlayerOptions = g.PlayerOptions,
                    GameModes = g.GameModes,
                    ImageUrl = g.ImageUrl, 
                    
                })
                .SingleOrDefault();

            if (gameDetailsViewModel == null)
            {
                return NotFound("Game not found. Please pick a valid game.");
            }

            return View(gameDetailsViewModel);
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
    }
}
