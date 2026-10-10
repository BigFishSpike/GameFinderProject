namespace GameFinder.Controllers
{
    using GameFinder.Data;
    using GameFinder.Data.Models;
    using GameFinder.ViewModels.Game;
    using GameFinder.ViewModels.Genre;
    using Microsoft.AspNetCore.Mvc;
    using static Common.ApplicationConstants;


    //Still need to add proper layout to Details page - very messy atm


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

        [HttpGet]
        public IActionResult Search(GameSearchViewModel resultGame)
        {
            IQueryable<Game> searchGame = dbContext.Games;
            
            ViewData["Genres"] = dbContext.Genres
                .OrderBy(g => g.Name)
                .ToList();

            if (!string.IsNullOrWhiteSpace(resultGame.Genre))
            {
                searchGame = searchGame
                    .Where(g => g.Genre.Name == resultGame.Genre);
            }

            if (resultGame.Difficulty.HasValue)
            {
                searchGame = searchGame
                    .Where(g => g.Difficulty == resultGame.Difficulty);
            }

            if (resultGame.PlayerOptions.HasValue)
            {
                searchGame = searchGame
                    .Where(g => g.PlayerOptions == resultGame.PlayerOptions);
            }

            if (resultGame.GameModes.HasValue)
            {
                searchGame = searchGame
                    .Where(g => g.GameModes == resultGame.GameModes);
            }

            resultGame.Games = searchGame
                .Select(g => new GameListViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                    ShowGenre = false
                })
                .ToList();
           
            return View(resultGame);
        }

        [HttpGet]
        public IActionResult ChooseGenre()
        {
            ViewData["Genres"] = dbContext.Genres
                .OrderBy(g => g.Name)
                .ToList();

            return View(new GameSearchViewModel());

        }
        
        [HttpGet]
        public IActionResult ChooseMode(GameSearchViewModel gameModel)
        {

            return View(gameModel);
        }

        [HttpGet]
        public IActionResult ChoosePlayers(GameSearchViewModel gameModel)
        {

            return View(gameModel);

        }

        [HttpGet]
        public IActionResult ChooseDifficulty(GameSearchViewModel gameModel)
        {

            return View(gameModel);

        }

        [HttpGet]
        public IActionResult ChooseResult(GameSearchViewModel gameResults)
        {
            IQueryable<Game> games = dbContext.Games;

            if (!string.IsNullOrWhiteSpace(gameResults.Genre))
            {
                games = games
                    .Where(g => g.Genre.Name == gameResults.Genre);
            }

            if (gameResults.GameModes.HasValue)
            {
                games = games
                    .Where(g => g.GameModes == gameResults.GameModes);
            }

            if (gameResults.PlayerOptions.HasValue)
            {
                games = games.Where(g =>
                    g.PlayerOptions == gameResults.PlayerOptions);
            }

            if (gameResults.Difficulty.HasValue)
            {
                games = games.Where(g =>
                    g.Difficulty == gameResults.Difficulty);
            }

            gameResults.Games = games
                .Select(g => new GameListViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                    ShowGenre = false,

                })
                .ToList();

            return View(gameResults);
        } 

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
    }
}
