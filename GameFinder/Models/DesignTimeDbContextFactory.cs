using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace GameFinder.Models
{
    public class GameFinderContextFactory : IDesignTimeDbContextFactory<GameFinderContext>
    {

        GameFinderContext IDesignTimeDbContextFactory<GameFinderContext>.CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<GameFinderContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString);

            return new GameFinderContext(builder.Options);
        }
    }
}