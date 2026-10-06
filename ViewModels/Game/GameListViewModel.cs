namespace GameFinder.ViewModels.Game
{
    public class GameListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string GenreName { get; set; } = null!;

        //maybe we'll add more, the above is just the starting point
        
    }
}
