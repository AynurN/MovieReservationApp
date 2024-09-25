using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieReservationApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedFullSeatsToShowTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FullSeats",
                table: "ShowTimes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullSeats",
                table: "ShowTimes");
        }
    }
}
