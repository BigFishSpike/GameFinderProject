using System.ComponentModel.DataAnnotations;

namespace GameFinder.ViewModels.Genre
{
    public class GenreListViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? ImageUrl { get; set; }

    }
}
