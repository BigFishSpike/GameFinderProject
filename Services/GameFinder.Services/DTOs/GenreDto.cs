namespace GameFinder.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using static GameFinder.Common.EntityValidation.Genre;

    public class GenreDto
    {
        [Key]
        public int Id { get; set; }

        [StringLength(GenreNameMaxLength, MinimumLength = GenreNameMinLength)]
        public string Name { get; set; } = null!;

        [MaxLength(GenreImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

    }
}
