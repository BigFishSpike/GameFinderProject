namespace GameFinder.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using static GameFinder.Common.EntityValidation.Genre;

    public class GenreDetailsDto : GenreDto
    {
        [MaxLength(GenreDescriptionMaxLength)]
        public string? Description { get; set; }

        public List<GameDto> Games { get; set; } = new List<GameDto>();

        public string? CreatedByUserId { get; set; }
    }
}
