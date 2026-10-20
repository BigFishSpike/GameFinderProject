namespace GameFinder.Data.Models
{
    using GameFinder.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    public class GamePlayerOption
    {
        [Key]
        public int GameId { get; set; }

        [Required]
        public virtual Game Game { get; set; } = null!;

        public PlayerOption PlayerOption { get; set; }
    }
}
