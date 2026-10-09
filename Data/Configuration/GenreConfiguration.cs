namespace GameFinder.Data.Configuration
{
    using GameFinder.Data.Models;
using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public static readonly IEnumerable<Genre> InitialSeedGenres = new List<Genre>()
        {
            new Genre
            {
                Id = 1, 
                Name = "RPG",
                Description = "Play through a story, complete quests, and grow stronger by earning experience points!",
                ImageUrl = "https://images.pexels.com/photos/7186550/pexels-photo-7186550.jpeg"
            },
            new Genre
            {
                Id = 2,
                Name = "FPS",
                Description = "Experience the thrill of combat through gunplay - be it tactical or fast-paced, the choice is yours.",
                ImageUrl = "https://st2.depositphotos.com/1327793/6774/i/950/depositphotos_67749521-stock-photo-a-gunfight-at-old-tucson.jpg"
            },
            new Genre
            {
                Id = 3,
                Name = "Roguelike",
                Description = "No run is the same - play through a randomized level every time, choose a different weapon or skill, and make every run your own.",
                ImageUrl = "https://t4.ftcdn.net/jpg/02/64/24/07/360_F_264240749_rZiS4JvhKf0lC0Nj9eBgFBn8r8FcEdFw.jpg"
            },
            new Genre
            {
                Id = 4,
                Name = "Survival",
                Description = "Think you can survive the harshness of the world? Then put that to the task in these games that will test your will as well as your mettle.",
                ImageUrl = "https://i.imgur.com/gJbYe0s.jpeg"
            },
            new Genre
            {
                Id = 5,
                Name = "Cleaning",
                Description = "Some people want action, combat, and guts to spill. And others want to clean up after those people, because to see an awful mess cleaned up completely is a reward in itself.",
                ImageUrl = "https://previews.123rf.com/images/ferli/ferli1312/ferli131200094/25147449-portrait-of-young-man-with-cleaning-equipment-ready-to-clean-the-house.jpg"
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
