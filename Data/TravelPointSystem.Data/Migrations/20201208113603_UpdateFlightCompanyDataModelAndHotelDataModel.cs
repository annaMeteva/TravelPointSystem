using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPointSystem.Data.Migrations
{
    public partial class UpdateFlightCompanyDataModelAndHotelDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FlightCompanies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Hotels",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FlightCompanies",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
