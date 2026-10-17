using GameFinder.Services.DTOs;
using GameFinder.Services.Interfaces;
using GameFinder.ViewModels.Game;
using Microsoft.AspNetCore.Mvc;

namespace GameFinder.Controllers
{
    public class UserFavouriteController : BaseController
    {
        private readonly IUserFavouriteService userFavouriteService;
        public UserFavouriteController(IUserFavouriteService userFavouriteService)
        {
            this.userFavouriteService = userFavouriteService;
        }

        public async Task<IActionResult> List()
        {
            string? userId = GetUserId();

            if (userId == null)
            {
                return Challenge();
            }

            IEnumerable<GameDto> favourites = await userFavouriteService
                .GetUserFavouritesAsync(userId);
            
            List<GameListViewModel> model = favourites.Select(game => new GameListViewModel
            {
                Id = game.Id,
                Name = game.Name,
                ImageUrl = game.ImageUrl,
                GenreName = game.GenreName,
                ShowGenre = true
            })
                .ToList();
            
            return View(model);
        }
    }
}
