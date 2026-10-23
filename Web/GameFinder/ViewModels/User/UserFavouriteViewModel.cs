namespace GameFinder.ViewModels.User
{
    using GameFinder.ViewModels.Game;

    public class UserFavouriteViewModel
    {
        public List<GameListViewModel> Games { get; set; } = new();
    }
}
