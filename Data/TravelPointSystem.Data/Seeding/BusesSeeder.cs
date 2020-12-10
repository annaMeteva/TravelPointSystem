namespace TravelPointSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Data.Models;

    public class BusesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Buses.Any())
            {
                return;
            }

            await dbContext.Buses.AddAsync(new Bus { DepartureDateTime = new DateTime(2021, 2, 2, 6, 50, 0), StartPointId = dbContext.Destinations.Single(d => d.Town == "Sofia").Id, EndPointId = dbContext.Destinations.Single(d => d.Town == "Prague").Id, AvailableSeats = 10, TravellingTime = new TimeSpan(15, 35, 0) });

            await dbContext.Buses.AddAsync(new Bus { DepartureDateTime = new DateTime(2021, 1, 12, 1, 20, 0), StartPointId = dbContext.Destinations.Single(d => d.Town == "Sofia").Id, EndPointId = dbContext.Destinations.Single(d => d.Town == "London").Id, AvailableSeats = 10, TravellingTime = new TimeSpan(20, 35, 0) });

            await dbContext.Buses.AddAsync(new Bus { DepartureDateTime = new DateTime(2021, 2, 5, 7, 55, 0), StartPointId = dbContext.Destinations.Single(d => d.Town == "Sofia").Id, EndPointId = dbContext.Destinations.Single(d => d.Town == "Madrid").Id, AvailableSeats = 10, TravellingTime = new TimeSpan(21, 35, 0) });

            await dbContext.Buses.AddAsync(new Bus { DepartureDateTime = new DateTime(2021, 2, 9, 3, 30, 0), StartPointId = dbContext.Destinations.Single(d => d.Town == "Sofia").Id, EndPointId = dbContext.Destinations.Single(d => d.Town == "Zagreb").Id, AvailableSeats = 10, TravellingTime = new TimeSpan(5, 35, 0) });

            await dbContext.Buses.AddAsync(new Bus { DepartureDateTime = new DateTime(2021, 1, 23, 6, 35, 0), StartPointId = dbContext.Destinations.Single(d => d.Town == "Sofia").Id, EndPointId = dbContext.Destinations.Single(d => d.Town == "Rome").Id, AvailableSeats = 10, TravellingTime = new TimeSpan(7, 35, 0) });

            await dbContext.Buses.AddAsync(new Bus { DepartureDateTime = new DateTime(2021, 2, 15, 2, 15, 0), StartPointId = dbContext.Destinations.Single(d => d.Town == "Sofia").Id, EndPointId = dbContext.Destinations.Single(d => d.Town == "Brussels").Id, AvailableSeats = 10, TravellingTime = new TimeSpan(9, 35, 0) });

            await dbContext.SaveChangesAsync();
        }
    }
}
