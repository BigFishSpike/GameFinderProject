using System.ComponentModel.DataAnnotations;

namespace GameFinder.ViewModels.Game
{
    public class GameListViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        public string GenreName { get; set; } = null!;

        public bool ShowGenre { get; set; } = true; 
        
        public bool IsFavourite { get; set; }
    }
}
