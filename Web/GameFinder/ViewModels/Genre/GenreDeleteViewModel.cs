using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameFinder.ViewModels.Genre
{
    public class GenreDeleteViewModel
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        [Required(ErrorMessage = "Please select a replacement genre.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid replacement genre.")]
        public int ReplacementGenreId { get; set; }

        public List<SelectListItem> ReplacementGenre { get; set; } = new();
    }
}
