using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameFinder.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Difficulty = table.Column<int>(type: "int", nullable: true),
                    PlayerOptions = table.Column<int>(type: "int", nullable: true),
                    GameModes = table.Column<int>(type: "int", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(2083)", maxLength: 2083, nullable: true),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Play through a story, complete quests, and grow stronger by earning experience points!", "RPG" },
                    { 2, "Experience the thrill of combat through gunplay - be it tactical, or fast-paced, the choice is yours.", "FPS" },
                    { 3, "No run is the same - play through randomized level every time, choose a different weapon or skill, and make every run your own.", "Roguelike" },
                    { 4, "Think you can survive the harshnes of the world? Then put that to the task in these games that will test your will and your mettle.", "Survival" },
                    { 5, "Some people want action, combat, and guts to spill. And others want to clean up after those people, because to see an awful mess cleaned up completely is a reward in itself.", "Cleaning" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Description", "Difficulty", "GameModes", "GenreId", "ImageUrl", "Name", "PlayerOptions", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "A fantastic journey through the cold North of Tamriel, where dragons have awoken once more to spread chaos upon the world.", 0, null, 1, "https://upload.wikimedia.org/wikipedia/en/1/15/The_Elder_Scrolls_V_Skyrim_cover.png?utm_source=en.wikipedia.org&utm_campaign=index&utm_content=original", "The Elder Scrolls V: Skyrim", 0, new DateOnly(2011, 11, 11) },
                    { 2, "Take upon the mantle of Witcher and play through the story of the legendary Geralt of Rivia, on his perilous quest through the Northern Realms to find his adopted daughter Ciri and stop the Wild Hunt, once and for all.", 0, null, 1, "https://thumb.wikimedia.org/wikipedia/en/thumb/0/0c/Witcher_3_cover_art.jpg/250px-Witcher_3_cover_art.jpg?utm_source=en.wikipedia.org&utm_campaign=parser&utm_content=thumbnail", "The Witcher 3: Wild Hunt", 0, new DateOnly(2015, 5, 19) },
                    { 3, "Death is all that awaits you, stranger. Yet, would you dare become a hero, and enter the hallowed world of Lordran? If so - prepare to die, hero.", 4, 2, 1, "https://upload.wikimedia.org/wikipedia/en/8/8d/Dark_Souls_Cover_Art.jpg?utm_source=en.wikipedia.org&utm_campaign=index&utm_content=original", "Dark Souls", 4, new DateOnly(2012, 8, 24) },
                    { 4, "Assemble your crew, and jump into this space-faring adventure as you navigate various missions together as a unit.", 3, 0, 2, "https://images.squarespace-cdn.com/content/v1/61a0b244de2c6f4f7fbc4108/c0e96d30-f186-4cc7-88db-b30b1b78c98f/JumpSpace_Wallpaper_4k.png", "Jump Space", 3, new DateOnly(2025, 9, 19) },
                    { 5, "The world is in ruin, overrun by the very spawn of hell itself. But one man alone stands against the terror, to rip and tear until it is done.", 0, 2, 2, "https://thumb.wikimedia.org/wikipedia/en/thumb/2/28/Doom_Cover.jpg/250px-Doom_Cover.jpg?utm_source=en.wikipedia.org&utm_campaign=parser&utm_content=thumbnail", "Doom", 4, new DateOnly(2016, 5, 13) },
                    { 6, "The classic competitive shooter, now with improved graphics and physics like never before. Enter the new era of Counter-Strike today, and prove that you're still worthy!", 4, 1, 2, "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/730/6328493f4cc4a8fb83e1149be1cac5a7823fe588/capsule_616x353.jpg?t=1789251637", "Counter-Strike 2", 3, new DateOnly(2023, 9, 27) },
                    { 7, "Escape the Underworld(and your responsibilties) in this Godlike-Roguelike!", 0, null, 3, "https://upload.wikimedia.org/wikipedia/en/c/cc/Hades_cover_art.jpg?utm_source=en.wikipedia.org&utm_campaign=index&utm_content=original", "Hades", 0, new DateOnly(2020, 9, 17) },
                    { 8, "Live. Die. Repeat. Fight your way out, or die trying. Then do it again. Also, make sure to deposit your cells before dying or you will be very mad at yourself!", 3, null, 3, "https://upload.wikimedia.org/wikipedia/en/1/1f/Dead_cells_cover_art.png?utm_source=en.wikipedia.org&utm_campaign=index&utm_content=original", "Dead Cells", 0, new DateOnly(2019, 8, 7) },
                    { 9, "Help Isaac overcome his Mother's fury in the classic, groundbreaking, and still difficult-as-ever game.", 4, null, 3, "https://thumb.wikimedia.org/wikipedia/en/thumb/f/fa/Binding_of_isaac_header.jpg/250px-Binding_of_isaac_header.jpg?utm_source=en.wikipedia.org&utm_campaign=parser&utm_content=thumbnail", "Binding of Isaac", 0, new DateOnly(2011, 9, 28) },
                    { 10, "An underwater adventure awaits in this unforgettable, and terrifying, survival game.", 2, null, 4, "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/264710/header.jpg?t=1777456112", "Subnautica", 0, new DateOnly(2018, 1, 23) },
                    { 11, "Hail, warrior. Your time among the living has passed, but your duty has not. You are of Odyn's chosen, blessed with the task to help unite the Tenth World. Fulfill your destiny, brave warrior, and help banish the chaos.", 3, 0, 4, "https://upload.wikimedia.org/wikipedia/en/7/77/Valheim_2021_logo.jpg?utm_source=en.wikipedia.org&utm_campaign=index&utm_content=original", "Valheim", 4, new DateOnly(2026, 9, 9) },
                    { 12, "Survival. Crafting. Zombies. And also a lot of difficulty that glues it all together. This is the ultimate survival experience, but the question is - how long can YOU survive?", 4, 0, 4, "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/108600/header.jpg?t=1787740093", "Project Zomboid", 4, new DateOnly(2026, 9, 9) },
                    { 13, "Experience the thrill of owning a powerwasher, and using it to clean the world of fiflth. The soothing sounds of the water are a bonus.", 1, 0, 5, "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1290000/0184e192ea58230dd82aa8aed8134be3ed8fc4c2/capsule_616x353.jpg?t=1780392261", "Powerwash Simulator", 4, new DateOnly(2026, 9, 9) },
                    { 14, "First of all, no, it's not what you think it is. Second - SOMEONE has to clean-up after all those nosy adventurers wreaking havoc on the dungeon. And third, yes you can wear a maid outfit. Yes, even as a male goblin.", 2, 0, 5, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQGN9aGZpAO7FsqFOOr1ZVSrTeExazop2kQQnVMwTO8-TTRJvtc4B8jTp3E&s=10", "Goblin Cleanup", 4, new DateOnly(2025, 9, 18) },
                    { 15, "The original clean-up game, the one to inspire many others, and the one that is still hardest to play because someone just can't stop kicking down the blood-filled buckets. You know who you are.", 4, 0, 5, "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/246900/header.jpg?t=1666984711", "Viscera Cleanup Detail", 4, new DateOnly(2015, 10, 23) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_GenreId",
                table: "Games",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
