using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplikacja_webowa___Football.Migrations
{
    public partial class UpdateMatchModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PenaltyScore",
                table: "Matches");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PenaltyScore",
                table: "Matches",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true);
        }
    }
}
