using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameFinder.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGameDifficulties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 0, 1 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 0, 2 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 0, 5 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 0, 7 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.InsertData(
                table: "GameDifficulty",
                columns: new[] { "Difficulty", "GameId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 3, 2 },
                    { 3, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 },
                    { 3, 6 },
                    { 1, 7 },
                    { 2, 7 },
                    { 3, 7 },
                    { 2, 8 },
                    { 3, 9 },
                    { 1, 10 },
                    { 3, 10 },
                    { 2, 11 },
                    { 3, 12 },
                    { 0, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 2, 15 },
                    { 3, 15 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 0, 13 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 1, 15 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "GameDifficulty",
                keyColumns: new[] { "Difficulty", "GameId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.InsertData(
                table: "GameDifficulty",
                columns: new[] { "Difficulty", "GameId" },
                values: new object[,]
                {
                    { 0, 1 },
                    { 0, 2 },
                    { 4, 3 },
                    { 0, 5 },
                    { 4, 6 },
                    { 0, 7 },
                    { 4, 9 },
                    { 4, 12 },
                    { 4, 15 }
                });
        }
    }
}
