namespace GameFinder.Controllers
{
    using GameFinder.Services.DTOs;
    using GameFinder.Services.Interfaces;
    using GameFinder.ViewModels.Game;
    using GameFinder.ViewModels.User;
    using Microsoft.AspNetCore.Mvc;

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
                    ShowGenre = true,
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

            TempData["SuccessMessage"] = "The game has been added to your Games List!";

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }

            return RedirectToAction("List", "Game");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove([FromForm]int gameId, string? returnUrl) 
        {

            string? userId = GetUserId();

            if (userId == null)
            {
                return Challenge();
            }
            
            bool removed = await userFavouriteService.RemoveFavouriteAsync(userId, gameId);

            if (removed)
            {
                TempData["SuccessMessage"] = "The game has been removed from your list.";
            }
            else
            {
                TempData["ErrorMessage"] = "Game not found.";
            }

            if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                return LocalRedirect(returnUrl);
            }

            await userFavouriteService.RemoveFavouriteAsync(userId, gameId);

            return RedirectToAction(nameof(List));
        }
    }
}
