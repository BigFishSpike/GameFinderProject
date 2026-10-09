namespace GameFinder.ViewModels.Genre
{
    using GameFinder.ViewModels.Game;
    public class GenreDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string? Description { get; set; }

        public virtual IEnumerable<GameListViewModel> Games { get; set; } 
            = new List<GameListViewModel>();
    }
}
