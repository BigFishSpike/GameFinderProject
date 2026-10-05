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
            new Genre{Id = 1, Name = "RPG"},
            new Genre{Id = 2, Name = "FPS"},
            new Genre{Id = 3, Name = "Roguelike"},
            new Genre{Id = 4, Name = "Survival"},
            new Genre{Id = 5, Name = "Cleaning"},

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
