using Microsoft.EntityFrameworkCore.Migrations;

namespace GameFinder.Migrations
{
    public partial class SeedMoreGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "AvgPlayTime", "MaxPlayers", "MinAge", "MinPlayers", "Name", "Publisher", "Type" },
                values: new object[,]
                {
                    { 11, 120, 6, 14, 1, "Zombicide", "Guillotine Games", "Strategy" },
                    { 12, 120, 5, 14, 1, "Sythe", "Stonemeier Games", "Strategy" },
                    { 13, 120, 6, 12, 1, "Rummy", "None", "Card" },
                    { 14, 60, 6, 7, 2, "Phase 10", "Mattel", "Card" },
                    { 15, 360, 10, 12, 3, "Dungeons & Dragons", "Wizards of the Coast", "RPG" },
                    { 16, 60, 5, 12, 2, "Magic the Gathering", "Wizards of the Coast", "Card" },
                    { 17, 60, 10, 12, 4, "Apples to Apples", "Mattel", "Card" },
                    { 18, 60, 6, 12, 3, "Betrayal at House on the Hill", "Avalon Hill Games, Inc", "Board" },
                    { 19, 90, 8, 13, 1, "Elder Sign", "Fantasy Fight Games", "Board" },
                    { 20, 60000, 8, 17, 1, "Skyrim", "Bethesda Softworks", "Video" },
                    { 21, 120, 4, 12, 1, "Giant Killer Robots", "Weta Workshop", "Tabletop" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "GameId",
                keyValue: 21);
        }
    }
}
