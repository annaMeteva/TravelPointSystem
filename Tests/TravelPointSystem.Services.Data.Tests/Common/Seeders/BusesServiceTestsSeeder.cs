namespace TravelPointSystem.Services.Data.Tests.Common.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Data;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;

    public class BusesServiceTestsSeeder
    {
        public async Task SeedBusAsync(ApplicationDbContext context)
        {
            var bus = new Bus
            {
                BusNumber = "BusNumber",
                AvailableSeats = 20,
                PricePerPerson = 20,
                ReservationType = ReservationType.Bus,
                StartPointId = 1,
                StartPointStation = "StartStation",
                EndPointId = 2,
                EndPointStation = "EndStation",
                DepartureDateTime = new DateTime(2020, 03, 03, 13, 00, 00),
                TravellingTime = new TimeSpan(30, 30, 00),
            };

            await context.Buses.AddAsync(bus);
            await context.SaveChangesAsync();
        }
    }
}
