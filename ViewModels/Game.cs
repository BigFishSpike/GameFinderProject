namespace GameFinder.ViewModels
{
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

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }

        [Required]
        public virtual Genre Genre { get; set; } = null!;

        
    }
}
