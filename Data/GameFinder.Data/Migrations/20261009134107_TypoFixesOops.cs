using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameFinder.Data.Migrations
{
    /// <inheritdoc />
    public partial class TypoFixesOops : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Experience the thrill of combat through gunplay - be it tactical or fast-paced, the choice is yours.");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "No run is the same - play through a randomized level every time, choose a different weapon or skill, and make every run your own.");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Think you can survive the harshness of the world? Then put that to the task in these games that will test your will as well as your mettle.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Experience the thrill of combat through gunplay - be it tactical, or fast-paced, the choice is yours.");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "No run is the same - play through randomized level every time, choose a different weapon or skill, and make every run your own.");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Think you can survive the harshnes of the world? Then put that to the task in these games that will test your will and your mettle.");
        }
    }
}
