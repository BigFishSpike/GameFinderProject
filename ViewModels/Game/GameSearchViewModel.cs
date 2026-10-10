using GameFinder.Data.Models.Enums;

namespace GameFinder.ViewModels.Game
{
    public class GameSearchViewModel
    {
        public string? Genre { get; set; }

        public PlayerOptions? PlayerOptions { get; set; }

        public GameModes? GameModes { get; set; }

        public Difficulty? Difficulty { get; set; }
        public List<GameListViewModel> Games { get; set; }
           = new List<GameListViewModel>();
    }
}
