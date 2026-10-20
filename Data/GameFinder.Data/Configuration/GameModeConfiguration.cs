namespace GameFinder.Data.Configuration
{
    using GameFinder.Data.Models.Enums;
    using GameFinder.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GameModeConfiguration : IEntityTypeConfiguration<GameMode>
    {
        public static readonly IEnumerable<GameMode> InitialSeedModes = new List<GameMode>()
        {
            new GameMode
            {
                GameId = 1, Mode = Mode.PvE
            },
            new GameMode
            {
                GameId = 2, Mode = Mode.PvE
            },
            new GameMode
            {
                GameId = 3, Mode = Mode.PvE
            },            
            new GameMode
            {
                GameId = 3, Mode = Mode.PvP
            },
            new GameMode
            {
                GameId = 4, Mode = Mode.PvE
            },          
            new GameMode
            {
                GameId = 5, Mode = Mode.PvE
            },
            new GameMode
            {
                GameId = 5, Mode = Mode.PvP
            },
            new GameMode
            {
                GameId = 6, Mode = Mode.PvP
            },
            new GameMode
            {
                GameId = 7, Mode = Mode.PvE
            },
            new GameMode
            {
                GameId = 8, Mode = Mode.PvE
            },
            new GameMode
            {
                GameId = 9, Mode = Mode.PvE
            },
            new GameMode
            {
                GameId = 10, Mode = Mode.PvE
            },
            new GameMode
            {
                GameId = 11, Mode = Mode.PvE
            },
            new GameMode
            {
                GameId = 11, Mode = Mode.PvP
            },
            new GameMode
            {
                GameId = 12, Mode = Mode.PvE
            },  
            new GameMode
            {
                GameId = 12, Mode = Mode.PvP
            },
            new GameMode
            {
                GameId = 12, Mode = Mode.PvPvE
            },
            new GameMode
            {
                GameId = 13, Mode = Mode.PvE
            },
            new GameMode
            {
                GameId = 14, Mode = Mode.PvE
            },
            new GameMode
            {
                GameId = 15, Mode = Mode.PvE
            },

        };
        public void Configure(EntityTypeBuilder<GameMode> builder)
        {
            builder.HasKey(gm => new
            {
                gm.GameId,
                gm.Mode,
            });

            builder.HasOne(gm => gm.Game)
                .WithMany(g => g.Modes)
                .HasForeignKey(gm => gm.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(InitialSeedModes);
        }
    }
}
