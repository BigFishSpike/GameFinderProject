namespace GameFinder.Data.Configuration
{
    using GameFinder.Data.Models.Enums;
    using GameFinder.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GamePlayerOptionConfiguration : IEntityTypeConfiguration<GamePlayerOption>
    {
        public static readonly IEnumerable<GamePlayerOption> InitialSeedPlayerOptions = new List<GamePlayerOption>()
        {
            new GamePlayerOption
            {
                GameId = 1, PlayerOption = PlayerOption.Singleplayer
            },
            new GamePlayerOption
            {
                GameId = 2, PlayerOption = PlayerOption.Singleplayer
            },
            new GamePlayerOption
            {
                GameId = 3, PlayerOption = PlayerOption.Singleplayer
            },
            new GamePlayerOption
            {
                GameId = 3, PlayerOption = PlayerOption.OnlineCoOp
            },            
            new GamePlayerOption
            {
                GameId = 3, PlayerOption = PlayerOption.Multiplayer
            },
            new GamePlayerOption
            {
                GameId = 4, PlayerOption = PlayerOption.Singleplayer
            },
            new GamePlayerOption
            {
                GameId = 4, PlayerOption = PlayerOption.OnlineCoOp
            },
            new GamePlayerOption
            {
                GameId = 4, PlayerOption = PlayerOption.Multiplayer
            },
            new GamePlayerOption
            {
                GameId = 5, PlayerOption = PlayerOption.Singleplayer
            },
            new GamePlayerOption
            {
                GameId = 5, PlayerOption = PlayerOption.Multiplayer
            },
            new GamePlayerOption
            {
                GameId = 6, PlayerOption = PlayerOption.Multiplayer
            },
            new GamePlayerOption
            {
                GameId = 7, PlayerOption = PlayerOption.Singleplayer
            },
            new GamePlayerOption
            {
                GameId = 8, PlayerOption = PlayerOption.Singleplayer
            },
            new GamePlayerOption
            {
                GameId = 9, PlayerOption = PlayerOption.Singleplayer
            },       
            new GamePlayerOption
            {
                GameId = 9, PlayerOption = PlayerOption.LocalCoOp
            },  
            new GamePlayerOption
            {
                GameId = 9, PlayerOption = PlayerOption.OnlineCoOp
            },     
            new GamePlayerOption
            {
                GameId = 9, PlayerOption = PlayerOption.Multiplayer
            },
            new GamePlayerOption
            {
                GameId = 10, PlayerOption = PlayerOption.Singleplayer
            },
            new GamePlayerOption
            {
                GameId = 11, PlayerOption = PlayerOption.Singleplayer
            },
            new GamePlayerOption
            {
                GameId = 11, PlayerOption = PlayerOption.OnlineCoOp
            }, 
            new GamePlayerOption
            {
                GameId = 11, PlayerOption = PlayerOption.Multiplayer
            },
            new GamePlayerOption
            {
                GameId = 12, PlayerOption = PlayerOption.Singleplayer
            },
            new GamePlayerOption
            {
                GameId = 12, PlayerOption = PlayerOption.LocalCoOp
            },
            new GamePlayerOption
            {
                GameId = 12, PlayerOption = PlayerOption.OnlineCoOp
            },
            new GamePlayerOption
            {
                GameId = 12, PlayerOption = PlayerOption.Multiplayer
            },
            new GamePlayerOption
            {
                GameId = 13, PlayerOption = PlayerOption.Singleplayer
            },            
            new GamePlayerOption
            {
                GameId = 13, PlayerOption = PlayerOption.Multiplayer
            },
            new GamePlayerOption
            {
                GameId = 14, PlayerOption = PlayerOption.Singleplayer
            }, 
            new GamePlayerOption
            {
                GameId = 14, PlayerOption = PlayerOption.OnlineCoOp
            },
            new GamePlayerOption
            {
                GameId = 15, PlayerOption = PlayerOption.Singleplayer
            },   
            new GamePlayerOption
            {
                GameId = 15, PlayerOption = PlayerOption.LocalCoOp
            },
            new GamePlayerOption
            {
                GameId = 15, PlayerOption = PlayerOption.OnlineCoOp
            },

        };
        public void Configure(EntityTypeBuilder<GamePlayerOption> builder)
        {
            builder.HasKey(po => new
            {
                po.GameId,
                po.PlayerOption
            });

            builder.HasOne(po => po.Game)
                .WithMany(g => g.PlayerOptions)
                .HasForeignKey(po => po.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(InitialSeedPlayerOptions);
        }
    }
}
