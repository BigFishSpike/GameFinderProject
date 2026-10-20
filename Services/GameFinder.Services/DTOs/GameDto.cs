namespace GameFinder.Services.DTOs
{
    using System.ComponentModel.DataAnnotations;
    using static GameFinder.Common.EntityValidation.Game;
    using static GameFinder.Common.EntityValidation.Genre;

    public class GameDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GameNameMaxLength)]
        public string Name { get; set; } = null!;

        [MaxLength(GameImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [Required]
        [MaxLength(GenreNameMaxLength)]
        public string GenreName { get; set; } = null!;
    }
}
