using GameFinder.Data.Models.Enums;
using GameFinder.ViewModels.Genre;
using System.ComponentModel.DataAnnotations;

namespace GameFinder.ViewModels.Game
{
    public class GameSearchViewModel
    {
        public string? Genre { get; set; }

        public PlayerOption? PlayerOption { get; set; }

        public Mode? Mode { get; set; }

        public Difficulty? Difficulty { get; set; }

        public List<GameListViewModel> Games { get; set; } = new List<GameListViewModel>();

        public List<GenreListViewModel> Genres { get; set; } = new List<GenreListViewModel>();

        public bool Searched { get; set; }
    }
}
