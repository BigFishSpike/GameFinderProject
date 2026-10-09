namespace GameFinder.ViewModels.Game
{
    public class GameListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string GenreName { get; set; } = null!;
        
    }
}
