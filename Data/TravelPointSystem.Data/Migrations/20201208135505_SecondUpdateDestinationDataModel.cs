using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPointSystem.Data.Migrations
{
    public partial class SecondUpdateDestinationDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Destinations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Destinations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
