namespace GameFinder.Data.Configuration
{
    using GameFinder.Data.Models.Enums;
    using GameFinder.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GameDifficultyConfiguration : IEntityTypeConfiguration<GameDifficulty>
    {
        public static readonly IEnumerable<GameDifficulty> InitialSeedDifficulties = new List<GameDifficulty>()
        {
            new GameDifficulty
            {
                GameId = 1, Difficulty = Difficulty.Easy
            },
            new GameDifficulty
            {
                GameId = 1, Difficulty = Difficulty.Medium
            },
            new GameDifficulty
            {
                GameId = 1, Difficulty = Difficulty.Hard
            },
            new GameDifficulty
            {
                GameId = 2, Difficulty = Difficulty.Easy
            }, 
            new GameDifficulty
            {
                GameId = 2, Difficulty = Difficulty.Medium
            }, 
            new GameDifficulty
            {
                GameId = 2, Difficulty = Difficulty.Hard
            },
            new GameDifficulty
            {
                GameId = 3, Difficulty = Difficulty.Hard
            },
            new GameDifficulty
            {
                GameId = 4, Difficulty = Difficulty.Easy
            },       
            new GameDifficulty
            {
                GameId = 4, Difficulty = Difficulty.Medium 
            },            
            new GameDifficulty
            {
                GameId = 4, Difficulty = Difficulty.Hard
            },
            new GameDifficulty 
            {
                GameId = 5, Difficulty = Difficulty.Easy
            },            
            new GameDifficulty
            {
                GameId = 5, Difficulty = Difficulty.Medium
            },  
            new GameDifficulty
            {
                GameId = 5, Difficulty = Difficulty.Hard
            },
            new GameDifficulty 
            {
                GameId = 6, Difficulty = Difficulty.Hard 
            },        
            new GameDifficulty 
            {
                GameId = 7, Difficulty = Difficulty.Easy       
            },            
            new GameDifficulty
            {
                GameId = 7, Difficulty = Difficulty.Medium
            },    
            new GameDifficulty
            {
                GameId = 7, Difficulty = Difficulty.Hard
            },
            new GameDifficulty 
            {
                GameId = 8, Difficulty = Difficulty.Medium
            },            
            new GameDifficulty
            {
                GameId = 8, Difficulty = Difficulty.Hard
            },
            new GameDifficulty 
            {
                GameId = 9, Difficulty = Difficulty.Hard
            },
            new GameDifficulty 
            {
                GameId = 10, Difficulty = Difficulty.Easy
            },            
            new GameDifficulty
            {
                GameId = 10, Difficulty = Difficulty.Medium
            },           
            new GameDifficulty
            {
                GameId = 10, Difficulty = Difficulty.Hard
            },
            new GameDifficulty
            {
                GameId = 11, Difficulty = Difficulty.Medium
            },            
            new GameDifficulty
            {
                GameId = 11, Difficulty = Difficulty.Hard
            },
            new GameDifficulty 
            {
                GameId = 12, Difficulty = Difficulty.Hard 
            },
            new GameDifficulty
            {
                GameId = 13, Difficulty = Difficulty.Casual
            },            
            new GameDifficulty
            {
                GameId = 13, Difficulty = Difficulty.Easy
            },
            new GameDifficulty
            {
                GameId = 14, Difficulty = Difficulty.Easy
            },              
            new GameDifficulty
            {
                GameId = 14, Difficulty = Difficulty.Medium
            },
            new GameDifficulty
            {
                GameId = 15, Difficulty = Difficulty.Easy
            },
            new GameDifficulty
            {
                GameId = 15, Difficulty = Difficulty.Medium
            },
            new GameDifficulty 
            {
                GameId = 15, Difficulty = Difficulty.Hard
            }

        };

        public void Configure(EntityTypeBuilder<GameDifficulty> builder)
        {
            builder.HasKey(gd => new
            {
                gd.GameId,
                gd.Difficulty,
            });

            builder.HasOne(gd => gd.Game)
                .WithMany(g=> g.Difficulties)
                .HasForeignKey(gd => gd.GameId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(InitialSeedDifficulties);


        }
    }
}
