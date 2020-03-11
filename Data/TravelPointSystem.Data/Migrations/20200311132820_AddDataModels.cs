using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelPointSystem.Data.Migrations
{
    public partial class AddDataModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TravelLicenceNumber",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Destinations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Continent = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Flag = table.Column<string>(nullable: false),
                    Town = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Logo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrganizedTrips",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    PricePerPerson = table.Column<double>(nullable: false),
                    DepartureDateTime = table.Column<DateTime>(nullable: false),
                    ReturnDateTime = table.Column<DateTime>(nullable: false),
                    Days = table.Column<int>(nullable: false),
                    DestinationsNumber = table.Column<int>(nullable: false),
                    Transport = table.Column<int>(nullable: false),
                    AvailableSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizedTrips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    DepartureDateTime = table.Column<DateTime>(nullable: false),
                    ReturnDateTime = table.Column<DateTime>(nullable: true),
                    DaysLeft = table.Column<int>(nullable: false),
                    NumberOfToursts = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Balance = table.Column<double>(nullable: false),
                    MoneyLeft = table.Column<double>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    CreatorId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tourists",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    FullName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    PersonalNumber = table.Column<decimal>(nullable: false),
                    PassportNumber = table.Column<decimal>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tourists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DepartureDateTime = table.Column<DateTime>(nullable: false),
                    ReturnDateTime = table.Column<DateTime>(nullable: true),
                    AvailableSeats = table.Column<int>(nullable: false),
                    StartPointId = table.Column<int>(nullable: false),
                    EndPointId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buses_Destinations_EndPointId",
                        column: x => x.EndPointId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Buses_Destinations_StartPointId",
                        column: x => x.StartPointId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    DestinationId = table.Column<int>(nullable: false),
                    PricePerNightPerPerson = table.Column<double>(nullable: false),
                    Stars = table.Column<int>(nullable: false),
                    AvailableRooms = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    DepartureDateTime = table.Column<DateTime>(nullable: false),
                    ReturnDateTime = table.Column<DateTime>(nullable: true),
                    StartPointId = table.Column<int>(nullable: false),
                    EndPointId = table.Column<int>(nullable: false),
                    FlightTime = table.Column<DateTime>(nullable: false),
                    AvailableSeats = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_FlightCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "FlightCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Destinations_EndPointId",
                        column: x => x.EndPointId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_Destinations_StartPointId",
                        column: x => x.StartPointId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DestinationOrganizedTrips",
                columns: table => new
                {
                    DestinationId = table.Column<int>(nullable: false),
                    OrganizedTripId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationOrganizedTrips", x => new { x.DestinationId, x.OrganizedTripId });
                    table.ForeignKey(
                        name: "FK_DestinationOrganizedTrips_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DestinationOrganizedTrips_OrganizedTrips_OrganizedTripId",
                        column: x => x.OrganizedTripId,
                        principalTable: "OrganizedTrips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DestinationReservations",
                columns: table => new
                {
                    DestinationId = table.Column<int>(nullable: false),
                    ReservationId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationReservations", x => new { x.DestinationId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_DestinationReservations_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DestinationReservations_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationTourists",
                columns: table => new
                {
                    ReservationId = table.Column<string>(nullable: false),
                    TouristId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationTourists", x => new { x.ReservationId, x.TouristId });
                    table.ForeignKey(
                        name: "FK_ReservationTourists_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ReservationTourists_Tourists_TouristId",
                        column: x => x.TouristId,
                        principalTable: "Tourists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HotelOrganizedTrips",
                columns: table => new
                {
                    HotelId = table.Column<int>(nullable: false),
                    OrganizedTripId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelOrganizedTrips", x => new { x.HotelId, x.OrganizedTripId });
                    table.ForeignKey(
                        name: "FK_HotelOrganizedTrips_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HotelOrganizedTrips_OrganizedTrips_OrganizedTripId",
                        column: x => x.OrganizedTripId,
                        principalTable: "OrganizedTrips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buses_EndPointId",
                table: "Buses",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_IsDeleted",
                table: "Buses",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_StartPointId",
                table: "Buses",
                column: "StartPointId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationOrganizedTrips_OrganizedTripId",
                table: "DestinationOrganizedTrips",
                column: "OrganizedTripId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationReservations_ReservationId",
                table: "DestinationReservations",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_IsDeleted",
                table: "Destinations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FlightCompanies_IsDeleted",
                table: "FlightCompanies",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_CompanyId",
                table: "Flights",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_EndPointId",
                table: "Flights",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_IsDeleted",
                table: "Flights",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_StartPointId",
                table: "Flights",
                column: "StartPointId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelOrganizedTrips_OrganizedTripId",
                table: "HotelOrganizedTrips",
                column: "OrganizedTripId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_DestinationId",
                table: "Hotels",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_IsDeleted",
                table: "Hotels",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizedTrips_IsDeleted",
                table: "OrganizedTrips",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CreatorId",
                table: "Reservations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_IsDeleted",
                table: "Reservations",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationTourists_TouristId",
                table: "ReservationTourists",
                column: "TouristId");

            migrationBuilder.CreateIndex(
                name: "IX_Tourists_IsDeleted",
                table: "Tourists",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "DestinationOrganizedTrips");

            migrationBuilder.DropTable(
                name: "DestinationReservations");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "HotelOrganizedTrips");

            migrationBuilder.DropTable(
                name: "ReservationTourists");

            migrationBuilder.DropTable(
                name: "FlightCompanies");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "OrganizedTrips");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Tourists");

            migrationBuilder.DropTable(
                name: "Destinations");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TravelLicenceNumber",
                table: "AspNetUsers");
        }
    }
}
