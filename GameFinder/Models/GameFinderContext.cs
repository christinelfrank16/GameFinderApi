using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace GameFinder.Models
{
    public class GameFinderContext : IdentityDbContext<User>
    {
        public GameFinderContext(DbContextOptions options): base(options){ }

        public DbSet<Game> Games { get; set; }
        public DbSet<User> RegisteredUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

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

                    new Game { GameId = 10, Name = "Risk", Type = "Strategy", Publisher = "Hasbro", MaxPlayers = 6, MinPlayers = 2, MinAge = 6, AvgPlayTime = 360},

                    new Game { GameId = 11, Name = "Zombicide", Type = "Strategy", Publisher = "Guillotine Games", MaxPlayers = 6, MinPlayers = 1, MinAge = 14, AvgPlayTime = 120 },

                    new Game { GameId = 12, Name = "Sythe", Type = "Strategy", Publisher = "Stonemeier Games", MaxPlayers = 5, MinPlayers = 1, MinAge = 14, AvgPlayTime = 120 },

                    new Game { GameId = 13, Name = "Rummy", Type = "Card", Publisher = "None", MaxPlayers = 6, MinPlayers = 1, MinAge = 12, AvgPlayTime = 120 },

                    new Game { GameId = 14, Name = "Phase 10", Type = "Card", Publisher = "Mattel", MaxPlayers = 6, MinPlayers = 2, MinAge = 7, AvgPlayTime = 60 },

                    new Game { GameId = 15, Name = "Dungeons & Dragons", Type = "RPG", Publisher = "Wizards of the Coast", MaxPlayers = 10, MinPlayers = 3, MinAge = 12, AvgPlayTime = 360 },

                    new Game { GameId = 16, Name = "Magic the Gathering", Type = "Card", Publisher = "Wizards of the Coast", MaxPlayers = 5, MinPlayers = 2, MinAge = 12, AvgPlayTime = 60 },

                    new Game { GameId = 17, Name = "Apples to Apples", Type = "Card", Publisher = "Mattel", MaxPlayers = 10, MinPlayers = 4, MinAge = 12, AvgPlayTime = 60 },

                    new Game { GameId = 18, Name = "Betrayal at House on the Hill", Type = "Board", Publisher = "Avalon Hill Games, Inc", MaxPlayers = 6, MinPlayers = 3, MinAge = 12, AvgPlayTime = 60 },

                    new Game { GameId = 19, Name = "Elder Sign", Type = "Board", Publisher = "Fantasy Fight Games", MaxPlayers = 8, MinPlayers = 1, MinAge = 13, AvgPlayTime = 90 },

                    new Game { GameId = 20, Name = "Skyrim", Type = "Video", Publisher = "Bethesda Softworks", MaxPlayers = 8, MinPlayers = 1, MinAge = 17, AvgPlayTime = 60000 },

                    new Game { GameId = 21, Name = "Giant Killer Robots", Type = "Tabletop", Publisher = "Weta Workshop", MaxPlayers = 4, MinPlayers = 1, MinAge = 12, AvgPlayTime = 120 }

                );
        }
    }
}