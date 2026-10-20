using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameFinder.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGameImageUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://clan.akamai.steamstatic.com/images/44958487/56046af861e0708f746cfe95674484b941293c7b.jpg");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/f/f2/CS2_Cover_Art.jpg?utm_source=en.wikipedia.org&utm_campaign=imageinfo&utm_content=thumbnail_unscaled");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/M/MV5BZGIzMzI4NjMtNzZlYi00MDBiLTliN2QtYjk4M2FmODA0NDBhXkEyXkFqcGc@._V1_.jpg");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://store-images.s-microsoft.com/image/apps.18542.13571084888216164.64efec07-99a1-43e6-9f9f-994d4517a3a8.f7b6b5f5-12b9-45ee-94de-f768e09e9fce");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/M/MV5BNTA5ZDJkMzAtZGZkZC00MDk3LTkyZTktZTBjZjZiZDZmZjAxXkEyXkFqcGc@._V1_.jpg");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT8NYzktmOLpOkce2-OwOXWPtYmWzDD7eeeNTFxza9img&s=10");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://store-images.s-microsoft.com/image/apps.48927.14635753444392084.1a3c9a06-6b28-4fa0-8222-4f5d9347a752.9e307ef5-3086-4a35-b5f7-c377b5bac34f");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/M/MV5BMGIwMWJmYmEtMGZlMy00ZDc3LWI5YTktYWM0NjkxMDkyZjNjXkEyXkFqcGc@._V1_.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://images.squarespace-cdn.com/content/v1/61a0b244de2c6f4f7fbc4108/c0e96d30-f186-4cc7-88db-b30b1b78c98f/JumpSpace_Wallpaper_4k.png");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/730/6328493f4cc4a8fb83e1149be1cac5a7823fe588/capsule_616x353.jpg?t=1789251637");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/264710/header.jpg?t=1777456112");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/en/7/77/Valheim_2021_logo.jpg?utm_source=en.wikipedia.org&utm_campaign=index&utm_content=original");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImageUrl",
                value: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/108600/header.jpg?t=1787740093");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 13,
                column: "ImageUrl",
                value: "https://shared.fastly.steamstatic.com/store_item_assets/steam/apps/1290000/0184e192ea58230dd82aa8aed8134be3ed8fc4c2/capsule_616x353.jpg?t=1780392261");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 14,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQGN9aGZpAO7FsqFOOr1ZVSrTeExazop2kQQnVMwTO8-TTRJvtc4B8jTp3E&s=10");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 15,
                column: "ImageUrl",
                value: "https://shared.akamai.steamstatic.com/store_item_assets/steam/apps/246900/header.jpg?t=1666984711");
        }
    }
}
