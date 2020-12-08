using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPointSystem.Data.Migrations
{
    public partial class UpdateDataModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyLeft",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "OrganizedTrips");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrganizedTrips");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "FlightCompanies");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReservationTourists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Profit",
                table: "Reservations",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HotelOrganizedTrips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DestinationReservations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DestinationOrganizedTrips",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReservationTourists");

            migrationBuilder.DropColumn(
                name: "Profit",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HotelOrganizedTrips");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DestinationReservations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DestinationOrganizedTrips");

            migrationBuilder.AddColumn<double>(
                name: "MoneyLeft",
                table: "Reservations",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Days",
                table: "OrganizedTrips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrganizedTrips",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "FlightCompanies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
