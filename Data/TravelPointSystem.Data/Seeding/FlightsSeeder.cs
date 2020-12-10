namespace TravelPointSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TravelPointSystem.Data.Models;

    public class FlightsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Flights.Any())
            {
                return;
            }

            await dbContext.Flights.AddAsync(new Flight { CompanyId = dbContext.FlightCompanies.Single(fc => fc.Name == "Ryanair").Id, DepartureDateTime = new DateTime(2021, 3, 6, 6, 30, 0), FlightTime = new TimeSpan(1, 35, 0), StartPointId = dbContext.Destinations.Single(d => d.Town == "Vienna").Id, EndPointId = dbContext.Destinations.Single(d => d.Town == "Berlin").Id, AvailableSeats = 50 });

            await dbContext.Flights.AddAsync(new Flight { CompanyId = dbContext.FlightCompanies.Single(fc => fc.Name == "Bulgaria Air").Id, DepartureDateTime = new DateTime(2021, 1, 6, 5, 40, 0), FlightTime = new TimeSpan(1, 55, 0), StartPointId = dbContext.Destinations.Single(d => d.Town == "Paris").Id, EndPointId = dbContext.Destinations.Single(d => d.Town == "Sofia").Id, AvailableSeats = 50 });

            await dbContext.Flights.AddAsync(new Flight { CompanyId = dbContext.FlightCompanies.Single(fc => fc.Name == "Wizzair").Id, DepartureDateTime = new DateTime(2021, 1, 26, 1, 30, 0), FlightTime = new TimeSpan(1, 10, 0), StartPointId = dbContext.Destinations.Single(d => d.Town == "Prague").Id, EndPointId = dbContext.Destinations.Single(d => d.Town == "Zagreb").Id, AvailableSeats = 50 });

            await dbContext.Flights.AddAsync(new Flight { CompanyId = dbContext.FlightCompanies.Single(fc => fc.Name == "Easyjet").Id, DepartureDateTime = new DateTime(2021, 3, 14, 3, 45, 0), FlightTime = new TimeSpan(2, 00, 0), StartPointId = dbContext.Destinations.Single(d => d.Town == "Athens").Id, EndPointId = dbContext.Destinations.Single(d => d.Town == "Rome").Id, AvailableSeats = 50 });

            await dbContext.Flights.AddAsync(new Flight { CompanyId = dbContext.FlightCompanies.Single(fc => fc.Name == "Lufthansa").Id, DepartureDateTime = new DateTime(2021, 3, 26, 4, 50, 0), FlightTime = new TimeSpan(1, 40, 0), StartPointId = dbContext.Destinations.Single(d => d.Town == "London").Id, EndPointId = dbContext.Destinations.Single(d => d.Town == "Madrid").Id, AvailableSeats = 50 });

            await dbContext.SaveChangesAsync();
        }
    }
}
