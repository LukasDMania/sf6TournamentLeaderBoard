using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewLEaderboard.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropfortourneydisplay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TournamentNameAndDateDisplay",
                table: "Tournament",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TournamentNameAndDateDisplay",
                table: "Tournament");
        }
    }
}
