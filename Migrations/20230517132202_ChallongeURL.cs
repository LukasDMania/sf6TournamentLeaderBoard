using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLEaderboard.Migrations
{
    /// <inheritdoc />
    public partial class ChallongeURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChallongeUrl",
                table: "Tournament",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChallongeUrl",
                table: "Tournament");
        }
    }
}
