namespace GameFinder.ViewModels.Genre
{
    using System.ComponentModel.DataAnnotations;
    using static GameFinder.Common.EntityValidation.Genre;

    public class GenreAddViewModel
    {
        [Required]
        [StringLength(GenreNameMaxLength, MinimumLength = GenreNameMinLength)]
        public string Name { get; set; } = null!;

        [MaxLength(GenreDescriptionMaxLength)]
        public string? Description { get; set; }

        [MaxLength(GenreImageUrlMaxLength)]
        public string? ImageUrl { get; set; }
    }
}
