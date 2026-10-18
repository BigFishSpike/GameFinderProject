namespace GameFinder.Controllers
{
    using GameFinder.Services.DTOs;
    using GameFinder.Services.Interfaces;
    using GameFinder.ViewModels.Game;
    using GameFinder.ViewModels.Genre;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static GameFinder.Common.EntityValidation;
    using static GameFinder.Common.EntityValidation.ApplicationConstants;

    //Still need to add proper layout to Details page - very messy atm

    public class GameController : BaseController
    {
        private readonly IGameService gameService;
        private readonly IGenreService genreService;
        private readonly IGameSearchValidator gameSearchValidator;

        public GameController(IGameService gameService, IGenreService genreService, IGameSearchValidator gameSearchValidator)
        {
            this.gameService = gameService;
            this.genreService = genreService;
            this.gameSearchValidator = gameSearchValidator;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> List()
        {
            IEnumerable<GameDto> games = await gameService
                .GetGamesList(EntitiesPerPage);

            IEnumerable<GameListViewModel> gameListViewModels = games
                .Select(g => new GameListViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                    GenreName = g.GenreName,
                })
                .ToList();

            return View(gameListViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Details([FromRoute]int? id)
        {
            if (!id.HasValue || id.Value <= 0)
            {
                return BadRequest("Incorrect value entered. Please try again.");
            }

            GameDetailsDto? gameDetailsDto = await gameService
                .GetGameDetails(id.Value);

            if (gameDetailsDto == null)
            {
                return NotFound("Game not found. Please pick a valid game.");
            }

            GameDetailsViewModel gameDetailsViewModel = new GameDetailsViewModel()
            {
                Id = gameDetailsDto.Id,
                Name = gameDetailsDto.Name,
                Description = gameDetailsDto.Description,
                Difficulties = gameDetailsDto.Difficulties,
                PlayerOptions = gameDetailsDto.PlayerOptions,
                GameModes = gameDetailsDto.GameModes,
                ImageUrl = gameDetailsDto.ImageUrl,
                ReleaseDate = gameDetailsDto.ReleaseDate,
            };


            return View(gameDetailsViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery]GameSearchViewModel gameModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid search parameters. Please try again.");
            }
            FindGameDto userRequests = new FindGameDto
            {
                Genre = gameModel.Genre,
                GameModes = gameModel.GameModes,
                PlayerOptions = gameModel.PlayerOptions,
                Difficulty = gameModel.Difficulty,
            };

            List<string> errors = await gameSearchValidator.ValidateAsync(userRequests);

            if (errors.Count > 0)
            {
                return BadRequest(errors);
            }

            IEnumerable<GameDto> gameDtos = await gameService
                .FindGames(userRequests);

            gameModel.Games = gameDtos
                .Select(g => new GameListViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                })
                .ToList();

            IEnumerable<GenreDto> genreDtos = await genreService
                .GetGenresList();

            gameModel.Genres = genreDtos
                .Select(g => new GenreListViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                })
                .ToList();


            return View(gameModel);
        }
        /*
         
      - needs to be reworked completely - will remove all the various Choose views as well; implementation is way too clunky, will use boxes instead of a filter like the quick one
         
        [HttpGet]
        public IActionResult ChooseGenre()
        {
            IEnumerable<GenreDto> genreDtos = genreService.GetGenresList();

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
           */

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
    }
}
