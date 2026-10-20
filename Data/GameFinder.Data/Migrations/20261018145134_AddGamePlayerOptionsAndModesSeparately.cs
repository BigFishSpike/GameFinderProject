using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameFinder.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGamePlayerOptionsAndModesSeparately : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameModes",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlayerOptions",
                table: "Games");

            migrationBuilder.CreateTable(
                name: "GameMode",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    Mode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameMode", x => new { x.GameId, x.Mode });
                    table.ForeignKey(
                        name: "FK_GameMode_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayerOption",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PlayerOption = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayerOption", x => new { x.GameId, x.PlayerOption });
                    table.ForeignKey(
                        name: "FK_GamePlayerOption_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameMode");

            migrationBuilder.DropTable(
                name: "GamePlayerOption");

            migrationBuilder.AddColumn<int>(
                name: "GameModes",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerOptions",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { 0, 3 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { null, 0 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { 0, 4 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { 0, 4 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { 0, 4 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { 0, 4 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "GameModes", "PlayerOptions" },
                values: new object[] { 0, 4 });
        }
    }
}
