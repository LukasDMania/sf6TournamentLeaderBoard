using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLEaderboard.Migrations
{
    /// <inheritdoc />
    public partial class addeddiscordtagtoplayermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "discordTag",
                table: "Player",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "discordTag",
                table: "Player");
        }
    }
}
