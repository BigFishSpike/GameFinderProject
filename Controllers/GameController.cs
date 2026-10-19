namespace GameFinder.Controllers
{
    using GameFinder.Services.DTOs;
    using GameFinder.Services.Interfaces;
    using GameFinder.ViewModels.Game;
    using GameFinder.ViewModels.Genre;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static GameFinder.Common.EntityValidation.ApplicationConstants;

    //Still need to add proper layout to Details page - very messy atm

    public class GameController : BaseController
    {
        private readonly IGameService gameService;
        private readonly IGenreService genreService;

        public GameController(IGameService gameService, IGenreService genreService)
        {
            this.gameService = gameService;
            this.genreService = genreService;
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
                Modes = gameDetailsDto.Modes,
                ImageUrl = gameDetailsDto.ImageUrl,
                ReleaseDate = gameDetailsDto.ReleaseDate,
            };


            return View(gameDetailsViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Search()
        {
            GameSearchViewModel gameModel = new GameSearchViewModel();

            IEnumerable<GenreDto> genres = await genreService.GetGenresList();

            gameModel.Genres = genres
                .Select(g => new GenreListViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToList();

            return View(gameModel);
        }

        [HttpPost]
        public async Task<IActionResult> Search(GameSearchViewModel gameModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid search parameters. Please try again.");
            }

            gameModel.Searched = true;

            FindGameDto userRequests = new FindGameDto
            {
                Genre = gameModel.Genre,
                Mode = gameModel.Mode,
                PlayerOptions = gameModel.PlayerOption,
                Difficulty = gameModel.Difficulty,
            };

            IEnumerable<GameDto> gameDtos = await gameService
                .FindGames(userRequests);

            gameModel.Games = gameDtos
                .Select(g => new GameListViewModel()
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl,
                })
                .Take(EntitiesPerPage)
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
       
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
    }
}
