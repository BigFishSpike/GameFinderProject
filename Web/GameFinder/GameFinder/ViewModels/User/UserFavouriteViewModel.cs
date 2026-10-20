using GameFinder.ViewModels.Game;

namespace GameFinder.ViewModels.User
{
    public class UserFavouriteViewModel
    {
        public List<GameListViewModel> Games { get; set; } = new();
    }
}
