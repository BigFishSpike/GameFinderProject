namespace GameFinder.Data.Models
{
    using GameFinder.Data.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    public class GameMode
    {
        [Required]
        public int GameId { get; set; }

        [Required]
        public virtual Game Game { get; set; } = null!;

        public Mode Mode { get; set; }
    }
}
