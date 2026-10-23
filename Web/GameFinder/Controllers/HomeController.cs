namespace GameFinder.Controllers
{
    using GameFinder.Services.DTOs;
    using GameFinder.Services.Interfaces;
    using GameFinder.ViewModels;
    using GameFinder.ViewModels.Game;
    using GameFinder.ViewModels.Genre;
    using GameFinder.ViewModels.Home;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    public class HomeController : BaseController
    {
        private readonly IGameService gameService;
        private readonly IGenreService genreService;
        private readonly IUserFavouriteService userFavouriteService;


        public HomeController(IGameService gameService, IGenreService genreService, IUserFavouriteService userFavouriteService)
        {
            this.gameService = gameService;
            this.genreService = genreService;
            this.userFavouriteService = userFavouriteService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<GameDto> games = await gameService.GetGamesList(6);

            HomeViewModel model = new HomeViewModel
            {
                FeaturedGames = games
                    .Select(g => new GameListViewModel
                    {
                        Id = g.Id,
                        Name = g.Name,
                        ImageUrl = g.ImageUrl,
                        GenreName = g.GenreName
                    })
                    .ToList()
            }; 
            
            IEnumerable<GenreDto> genres = await genreService.GenresGetList();

            model.FeaturedGenres = genres
                .Select(g => new GenreListViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    ImageUrl = g.ImageUrl
                })
                .Take(5)
                .ToList();

            string? userId = GetUserId();

            if (userId != null)
            {
                IEnumerable<GameDto> favourites = await userFavouriteService.GetUserFavouritesAsync(userId);

                model.UserFavouriteGames = favourites
                    .Select(g => new GameListViewModel
                    {
                        Id = g.Id,
                        Name = g.Name,
                        ImageUrl = g.ImageUrl,
                        GenreName = g.GenreName
                    })
                    .ToList();
            }

            return View(model);
        }
    }
}
