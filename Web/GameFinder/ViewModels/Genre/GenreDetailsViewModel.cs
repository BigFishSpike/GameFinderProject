namespace GameFinder.ViewModels.Genre
{
    using GameFinder.ViewModels.Game;
    using System.ComponentModel.DataAnnotations;

    public class GenreDetailsViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string? Description { get; set; }

        public virtual IEnumerable<GameListViewModel> Games { get; set; } 
            = new List<GameListViewModel>();

        public bool IsOwner { get; set; }
    }
}
