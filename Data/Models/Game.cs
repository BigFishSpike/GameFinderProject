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
        public string Name { get; set; } = null!; 

        [MaxLength(GameDescriptionMaxLength)]
        public string? Description { get; set; }

        public virtual Difficulty? Difficulty { get; set; }
        public virtual PlayerOptions? PlayerOptions { get; set; }
        public virtual GameModes? GameModes { get; set; }

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
