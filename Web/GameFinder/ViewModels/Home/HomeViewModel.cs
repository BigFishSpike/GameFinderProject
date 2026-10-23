namespace GameFinder.ViewModels.Home
{
    using GameFinder.ViewModels.Game;
    using GameFinder.ViewModels.Genre;

    public class HomeViewModel
    {
        public List<GameListViewModel> FeaturedGames { get; set; } = new();

        public List<GenreListViewModel> FeaturedGenres { get; set; } = new();

        public List<GameListViewModel> UserFavouriteGames { get; set; } = new();

    }
}
