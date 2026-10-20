using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameFinder.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixGameModeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "GameMode",
                columns: new[] { "GameId", "Mode" },
                values: new object[] { 4, 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameMode",
                keyColumns: new[] { "GameId", "Mode" },
                keyValues: new object[] { 4, 0 });

            migrationBuilder.InsertData(
                table: "GameMode",
                columns: new[] { "GameId", "Mode" },
                values: new object[] { 4, 1 });
        }
    }
}
