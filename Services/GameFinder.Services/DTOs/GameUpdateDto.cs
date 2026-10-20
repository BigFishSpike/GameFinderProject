namespace GameFinder.Services.DTOs
{
    using GameFinder.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using static GameFinder.Common.EntityValidation.Game;

    public class GameUpdateDto
    {
        [Key]
        public int Id { get; set; }

        [StringLength(GameNameMaxLength, MinimumLength = GameNameMinLength)]
        public string Name { get; set; } = null!;

        [MaxLength(GameDescriptionMaxLength)]
        public string? Description { get; set; }

        [MaxLength(GameImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public int GenreId { get; set; }

        public List<Difficulty> Difficulties { get; set; } = new List<Difficulty>();

        public List<PlayerOption> PlayerOptions { get; set; } = new List<PlayerOption>();

        public List<Mode> Modes { get; set; } = new List<Mode>();

    }
}
