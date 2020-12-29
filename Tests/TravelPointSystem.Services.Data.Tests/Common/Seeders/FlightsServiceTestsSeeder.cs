namespace TravelPointSystem.Services.Data.Tests.Common.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TravelPointSystem.Data;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;

    public class FlightsServiceTestsSeeder
    {
        public async Task SeedFlightAsync(ApplicationDbContext context)
        {
            var flight = new Flight
            {
                FlightNumber = "FlightNumber",
                AvailableSeats = 20,
                PricePerPerson = 20,
                ReservationType = ReservationType.Flight,
                StartPointId = 1,
                StartPointAirPort = "StartAirPort",
                EndPointId = 2,
                EndPointAirPort = "EndAirPort",
                DepartureDateTime = new DateTime(2020, 03, 03, 13, 00, 00),
                FlightTime = new TimeSpan(30, 30, 00),
                CompanyId = 1,
            };

            await context.Flights.AddAsync(flight);
            await context.SaveChangesAsync();
        }
    }
}
