namespace GameFinder.Data.Models
{
    using GameFinder.Data.Models;
    using GameFinder.Data.Models.Enums;
    using Microsoft.AspNetCore.Identity;
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

        public virtual ICollection<GameDifficulty> Difficulties { get; set; } = new List<GameDifficulty>();

        public virtual ICollection<GamePlayerOption> PlayerOptions { get; set; } = new List<GamePlayerOption>();

        public virtual ICollection<GameMode> Modes { get; set; } = new List<GameMode>();

        [MaxLength(GameImageUrlMaxLength)]
        public string? ImageUrl { get; set; }

        [Required]
        [Column(TypeName ="date")]
        public DateOnly ReleaseDate { get; set; }

        [Required]
        public int GenreId { get; set; }

        [ForeignKey(nameof(GenreId))]
        public virtual Genre Genre { get; set; } = null!;

        public string? CreatedByUserId { get; set; }

        public virtual IdentityUser? CreatedByUser { get; set; }
    }
}
