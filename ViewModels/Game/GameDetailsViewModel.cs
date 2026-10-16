using GameFinder.Data.Models.Enums;

namespace GameFinder.ViewModels.Game
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public List<Difficulty> Difficulties { get; set; } = new List<Difficulty>();

        public PlayerOptions? PlayerOptions { get; set; }

        public GameModes? GameModes { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public string? ImageUrl { get; set; }
    }
}
