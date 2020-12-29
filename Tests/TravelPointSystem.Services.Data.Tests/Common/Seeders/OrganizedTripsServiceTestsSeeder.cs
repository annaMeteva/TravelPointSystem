namespace TravelPointSystem.Services.Data.Tests.Common.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Data;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;

    public class OrganizedtripsServiceTestsSeeder
    {
        public async Task SeedTripAsync(ApplicationDbContext context)
        {
            var trip = new OrganizedTrip
            {
                Name = "TripName",
                ImageUrl = "ImageUrl",
                Description = "Description",
                DepartureDateTime = new DateTime(2020, 03, 03, 13, 00, 00),
                ReturnDateTime = new DateTime(2020, 03, 03, 13, 30, 00),
                DestinationId = 1,
                PricePerPerson = 50,
                HotelId = 1,
                AvailableSeats = 1,
                Transport = TransportType.Flight,
                ReservationType = ReservationType.OrganizedTrip,
            };

            await context.OrganizedTrips.AddAsync(trip);
            await context.SaveChangesAsync();
        }
    }
}
