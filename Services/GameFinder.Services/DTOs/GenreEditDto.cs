namespace GameFinder.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using static GameFinder.Common.EntityValidation.Genre;

    public class GenreEditDto : GenreDto
    {
        [MaxLength(GenreDescriptionMaxLength)]
        public string? Description { get; set; }

    }
}
