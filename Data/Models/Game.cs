namespace GameFinder.Data.Models
{
    using GameFinder.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static GameFinder.Common.EntityValidation.Game;

    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GameNameMaxLength)]
        public string Name { get; set; } = null!; //maybe change to title for consistency?

        [MaxLength(GameDescriptionMaxLength)]
        public string? Description { get; set; }

        public Difficulty? Difficulty { get; set; }
        public PlayerOptions? PlayerOptions { get; set; }
        public GameModes? GameModes { get; set; }

        [MaxLength(GameImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [Required]
        [Column(TypeName ="date")]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; } = null!;

        
    }
}
