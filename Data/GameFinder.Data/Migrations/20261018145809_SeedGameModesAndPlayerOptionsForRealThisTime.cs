using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameFinder.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedGameModesAndPlayerOptionsForRealThisTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GameMode",
                columns: new[] { "GameId", "Mode" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 0 },
                    { 3, 0 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 0 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 0 },
                    { 8, 0 },
                    { 9, 0 },
                    { 10, 0 },
                    { 11, 0 },
                    { 11, 1 },
                    { 12, 0 },
                    { 12, 1 },
                    { 12, 2 },
                    { 13, 0 },
                    { 14, 0 },
                    { 15, 0 }
                });

            migrationBuilder.InsertData(
                table: "GamePlayerOption",
                columns: new[] { "GameId", "PlayerOption" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 0 },
                    { 3, 0 },
                    { 3, 2 },
                    { 3, 3 },
                    { 4, 0 },
                    { 4, 2 },
                    { 4, 3 },
                    { 5, 0 },
                    { 5, 3 },
                    { 6, 3 },
                    { 7, 0 },
                    { 8, 0 },
                    { 9, 0 },
                    { 9, 1 },
                    { 9, 2 },
                    { 9, 3 },
                    { 10, 0 },
                    { 11, 0 },
                    { 11, 2 },
                    { 11, 3 },
                    { 12, 0 },
                    { 12, 1 },
                    { 12, 2 },
                    { 12, 3 },
                    { 13, 0 },
                    { 13, 3 },
                    { 14, 0 },
                    { 14, 2 },
                    { 15, 0 },
                    { 15, 1 },
                    { 15, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 1, 0 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 2, 0 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 3, 0 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 5, 0 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 7, 0 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 8, 0 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 9, 0 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 10, 0 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 11, 0 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 12, 0 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 13, 0 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 14, 0 });

            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 15, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 1, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 2, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 3, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 4, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 5, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 7, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 8, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 9, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 10, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 11, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 12, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 13, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 14, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 14, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 15, 0 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlayerOption",
                keyColumns: new[] { "GameId", "PlayerOption" },
                keyValues: new object[] { 15, 2 });
        }
    }
}
