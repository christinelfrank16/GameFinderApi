using Microsoft.EntityFrameworkCore;

namespace GameFinder.Models
{
    public class GameFinderContext : DbContext
    {
        public GameFinderContext(DbContextOptions<GameFinderContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Game>()
                .HasData(
                    
                );
        }
    }
}