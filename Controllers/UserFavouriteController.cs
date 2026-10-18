using GameFinder.Services.DTOs;
using GameFinder.Services.Interfaces;
using GameFinder.ViewModels.Game;
using GameFinder.ViewModels.User;
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

        [HttpGet]
        public async Task<IActionResult> List()
        {
            string? userId = GetUserId();

            if (userId == null)
            {
                return Challenge();
            }

            IEnumerable<GameDto> favourites = await userFavouriteService
                .GetUserFavouritesAsync(userId);

            UserFavouriteViewModel favouritesViewModel = new UserFavouriteViewModel
            { 
                Games = favourites
                .Select(game => new GameListViewModel
                {
                    Id = game.Id,
                    Name = game.Name,
                    ImageUrl = game.ImageUrl,
                    GenreName = game.GenreName,
                    ShowGenre = false
                })
                .ToList(),
            };

            return View(favouritesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([FromForm]int gameId, string? returnUrl)
        {
            string? userId = GetUserId();

            if (userId == null)
            {
                return Challenge();
            }

            await userFavouriteService.AddFavouriteAsync(userId, gameId);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("List", "Game");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove([FromForm]int gameId) 
        {

            string? userId = GetUserId();

            if (userId == null)
            {
                return Challenge();
            }

            await userFavouriteService.RemoveFavouriteAsync(userId, gameId);

            return RedirectToAction(nameof(List));
        }
    }
}
