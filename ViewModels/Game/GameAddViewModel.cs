namespace GameFinder.ViewModels.Game
{
    using GameFinder.ViewModels.Genre;
    using System.ComponentModel.DataAnnotations;
    using static GameFinder.Common.EntityValidation.Game;
    public class GameAddViewModel
    {
        [Required]
        [StringLength(GameNameMaxLength, MinimumLength = GameNameMinLength)]
        public string Name { get; set; } = null!;

        [MaxLength(GameDescriptionMaxLength)]
        public string? Description { get; set; }

        [MaxLength(GameImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public int GenreId { get; set; }

        public List<int> Difficulties { get; set; } = new List<int>();

        public List<int> PlayerOptions { get; set; } = new List<int>();

        public List<int> Modes { get; set; } = new List<int>();

        public List<GenreListViewModel> Genres { get; set; } = new List<GenreListViewModel>();

    }
}
