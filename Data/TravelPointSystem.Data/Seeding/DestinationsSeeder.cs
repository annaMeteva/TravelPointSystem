namespace TravelPointSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Data.Models;

    public class DestinationsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Destinations.Any())
            {
                return;
            }

            await dbContext.Destinations.AddAsync(new Destination {Continent = "Europe", Country = "Austria", Town = "Vienna" });
            await dbContext.Destinations.AddAsync(new Destination {Continent = "Europe", Country = "Belgium", Town = "Brussels" });
            await dbContext.Destinations.AddAsync(new Destination {Continent = "Europe", Country = "Bulgaria", Town = "Sofia" });
            await dbContext.Destinations.AddAsync(new Destination {Continent = "Europe", Country = "Croatia", Town = "Zagreb" });
            await dbContext.Destinations.AddAsync(new Destination {Continent = "Europe", Country = "Czechia", Town = "Prague" });
            await dbContext.Destinations.AddAsync(new Destination {Continent = "Europe", Country = "France", Town = "Paris" });
            await dbContext.Destinations.AddAsync(new Destination {Continent = "Europe", Country = "Germany", Town = "Berlin" });
            await dbContext.Destinations.AddAsync(new Destination {Continent = "Europe", Country = "Greece", Town = "Athens" });
            await dbContext.Destinations.AddAsync(new Destination { Continent = "Europe", Country = "Hungary", Town = "Budapest" });
            await dbContext.Destinations.AddAsync(new Destination { Continent = "Europe", Country = "Italy", Town = "Rome" });
            await dbContext.Destinations.AddAsync(new Destination { Continent = "Europe", Country = "Spain", Town = "Madrid" });
            await dbContext.Destinations.AddAsync(new Destination { Continent = "Europe", Country = "United Kingdom", Town = "London" });

            await dbContext.SaveChangesAsync();
        }
    }
}
