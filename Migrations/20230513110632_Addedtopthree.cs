using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLEaderboard.Migrations
{
    /// <inheritdoc />
    public partial class Addedtopthree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AmountFirstPlace",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountSecondPlace",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AmountThirdPlace",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountFirstPlace",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "AmountSecondPlace",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "AmountThirdPlace",
                table: "Player");
        }
    }
}
