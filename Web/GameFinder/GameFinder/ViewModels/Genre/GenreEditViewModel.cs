namespace GameFinder.ViewModels.Genre
{
    using static GameFinder.Common.EntityValidation.Genre;
    using System.ComponentModel.DataAnnotations;

    public class GenreEditViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(GenreNameMaxLength, MinimumLength = GenreNameMinLength)]
        public string Name { get; set; } = null!;

        [MaxLength(GenreDescriptionMaxLength)]
        public string? Description { get; set; }

        [MaxLength(GenreImageUrlMaxLength)]
        public string? ImageUrl { get; set; }
    }
}
