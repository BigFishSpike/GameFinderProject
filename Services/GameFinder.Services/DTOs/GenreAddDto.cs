namespace GameFinder.Services.DTOs
{
    using static GameFinder.Common.EntityValidation.Genre;
    using System.ComponentModel.DataAnnotations;

    public class GenreAddDto
    {
        [Required]
        [StringLength(GenreNameMaxLength, MinimumLength =  GenreNameMinLength)]
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public string CreatedByUserId { get; set; } = null!;
    }
}
