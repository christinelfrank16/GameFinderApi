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
                    new Game {GameId = 1, Name = "Scrabble", Type = "Board", Publisher = "Hasbro", MaxPlayers = 4, MinPlayers = 2, MinAge = 8, AvgPlayTime = 50},

                    new Game { GameId = 2, Name = "Chess", Type = "Strategy", Publisher = "None", MaxPlayers = 2, MinPlayers = 2, MinAge = 6, AvgPlayTime = 30},

                    new Game { GameId = 3, Name = "Monopoly", Type = "Board", Publisher = "Hasbro", MaxPlayers = 10, MinPlayers = 2, MinAge = 8, AvgPlayTime = 200},

                    new Game { GameId = 4, Name = "Trivial Pursuit", Type = "Board", Publisher = "Hasbro", MaxPlayers = 6, MinPlayers = 2, MinAge = 8, AvgPlayTime = 80},

                    new Game { GameId = 5, Name = "Backgammon", Type = "Strategy", Publisher = "None", MaxPlayers = 2, MinPlayers = 2, MinAge = 2, AvgPlayTime = 60},

                    new Game { GameId = 6, Name = "Jenga", Type = "Physical Skill", Publisher = "Hasbro", MaxPlayers = 15, MinPlayers = 1, MinAge = 6, AvgPlayTime = 10},

                    new Game { GameId = 7, Name = "Twister", Type = "Physical Skill", Publisher = "Milton Bradley", MaxPlayers = 4, MinPlayers = 4, MinAge = 6, AvgPlayTime = 10},

                    new Game { GameId = 8, Name = "Ticket to Ride", Type = "Board", Publisher = "Days of Wonder", MaxPlayers = 5, MinPlayers = 2, MinAge = 8, AvgPlayTime = 120},

                    new Game { GameId = 9, Name = "Operation", Type = "Physical Skill", Publisher = "Hasbro", MaxPlayers = 5, MinPlayers = 1, MinAge = 6, AvgPlayTime = 10},

                    new Game { GameId = 10, Name = "Risk", Type = "Strategy", Publisher = "Hasbro", MaxPlayers = 6, MinPlayers = 2, MinAge = 6, AvgPlayTime = 360}
                );
        }
    }
}