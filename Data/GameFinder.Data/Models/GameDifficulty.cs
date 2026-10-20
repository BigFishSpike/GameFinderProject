namespace GameFinder.Data.Models
{
    using GameFinder.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GameDifficulty
    {
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        [Required]
        public virtual Game Game { get; set; } = null!;

        public Difficulty Difficulty { get; set; }
    }
}
