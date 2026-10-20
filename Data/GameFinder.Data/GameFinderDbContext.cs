namespace GameFinder.Data
{
    using GameFinder.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class GameFinderDbContext : IdentityDbContext
    {
        public GameFinderDbContext(DbContextOptions<GameFinderDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public virtual DbSet<Genre> Genres { get; set; } = null!;

        public virtual DbSet<Game> Games { get; set; } = null!;

        public virtual DbSet<UserFavourite> UserFavourites { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameFinderDbContext).Assembly);
        }
    }
}
