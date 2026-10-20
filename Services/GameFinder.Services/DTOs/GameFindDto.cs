namespace GameFinder.Services.DTOs
{
    using GameFinder.Data.Models.Enums;

    public class GameFindDto
    {
        public string? Genre { get; set; }

        public Mode? Mode { get; set; }

        public PlayerOption? PlayerOptions { get; set; }

        public Difficulty? Difficulty { get; set; }
    }
}
