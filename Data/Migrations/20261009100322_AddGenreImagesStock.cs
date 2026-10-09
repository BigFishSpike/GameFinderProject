using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameFinder.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGenreImagesStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://images.pexels.com/photos/7186550/pexels-photo-7186550.jpeg");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://st2.depositphotos.com/1327793/6774/i/950/depositphotos_67749521-stock-photo-a-gunfight-at-old-tucson.jpg");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://t4.ftcdn.net/jpg/02/64/24/07/360_F_264240749_rZiS4JvhKf0lC0Nj9eBgFBn8r8FcEdFw.jpg");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: "https://i.imgur.com/gJbYe0s.jpeg");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: "https://previews.123rf.com/images/ferli/ferli1312/ferli131200094/25147449-portrait-of-young-man-with-cleaning-equipment-ready-to-clean-the-house.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: null);
        }
    }
}
