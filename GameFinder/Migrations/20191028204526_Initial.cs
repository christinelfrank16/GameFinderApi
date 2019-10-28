using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GameFinder.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    Publisher = table.Column<string>(nullable: true),
                    MaxPlayers = table.Column<int>(nullable: false),
                    MinPlayers = table.Column<int>(nullable: false),
                    MinAge = table.Column<int>(nullable: false),
                    AvgPlayTime = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "GameId", "AvgPlayTime", "MaxPlayers", "MinAge", "MinPlayers", "Name", "Publisher", "Type" },
                values: new object[,]
                {
                    { 1, 50, 4, 8, 2, "Scrabble", "Hasbro", "Board" },
                    { 2, 30, 2, 6, 2, "Chess", "None", "Strategy" },
                    { 3, 200, 10, 8, 2, "Monopoly", "Hasbro", "Board" },
                    { 4, 80, 6, 8, 2, "Trivial Pursuit", "Hasbro", "Board" },
                    { 5, 60, 2, 2, 2, "Backgammon", "None", "Strategy" },
                    { 6, 10, 15, 6, 1, "Jenga", "Hasbro", "Physical Skill" },
                    { 7, 10, 4, 6, 4, "Twister", "Milton Bradley", "Physical Skill" },
                    { 8, 120, 5, 8, 2, "Ticket to Ride", "Days of Wonder", "Board" },
                    { 9, 10, 5, 6, 1, "Operation", "Hasbro", "Physical Skill" },
                    { 10, 360, 6, 6, 2, "Risk", "Hasbro", "Strategy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
