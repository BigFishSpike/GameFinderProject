namespace GameFinder.Data.Configuration
{
    using GameFinder.Data.Models;
using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public static readonly IEnumerable<Genre> InitialSeedGenres = new List<Genre>()
        {
            new Genre
            {
                Id = 1, 
                Name = "RPG",
                Description = "Play through a story, complete quests, and grow stronger by earning experience points!"
            },
            new Genre
            {
                Id = 2,
                Name = "FPS",
                Description = "Experience the thrill of combat through gunplay - be it tactical, or fast-paced, the choice is yours.",
            },
            new Genre
            {
                Id = 3,
                Name = "Roguelike",
                Description = "No run is the same - play through randomized level every time, choose a different weapon or skill, and make every run your own.",
            },
            new Genre
            {
                Id = 4,
                Name = "Survival",
                Description = "Think you can survive the harshnes of the world? Then put that to the task in these games that will test your will and your mettle.",
            },
            new Genre
            {
                Id = 5,
                Name = "Cleaning",
                Description = "Some people want action, combat, and guts to spill. And others want to clean up after those people, because to see an awful mess cleaned up completely is a reward in itself.",
            },

        };

        public void Configure(EntityTypeBuilder<Genre> builder) 
        {
            builder.HasMany(g => g.Games)
                   .WithOne(g => g.Genre)
                   .HasForeignKey(g => g.GenreId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(g => g.Name)
                   .IsUnique();

            builder.HasData(InitialSeedGenres);

        }
    }
}
