using GameFinder.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace GameFinder.Data
{
    public class GameFinderDbContext : DbContext
    {
        public GameFinderDbContext(DbContextOptions<GameFinderDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public virtual DbSet<Genre> Genres { get; set; } = null!;

        public virtual DbSet<Game> Games { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GameFinderDbContext).Assembly);
        }
    }
}
