using GameFinder.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace GameFinder.ViewModels.Game
{
    public class GameDetailsViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public List<Difficulty> Difficulties { get; set; } = new List<Difficulty>();

        public List<PlayerOption> PlayerOptions { get; set; } = new List<PlayerOption>();

        public List<Mode> Modes { get; set; } = new List<Mode>();

        public DateOnly ReleaseDate { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsOwner { get; set; }
    }
}
