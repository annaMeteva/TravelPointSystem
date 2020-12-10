namespace TravelPointSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Data.Models;

    public class FlightCompaniesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.FlightCompanies.Any())
            {
                return;
            }

            await dbContext.FlightCompanies.AddAsync(new FlightCompany { Name = "Ryanair" });
            await dbContext.FlightCompanies.AddAsync(new FlightCompany { Name = "Easyjet" });
            await dbContext.FlightCompanies.AddAsync(new FlightCompany { Name = "Lufthansa" });
            await dbContext.FlightCompanies.AddAsync(new FlightCompany { Name = "Wizzair" });
            await dbContext.FlightCompanies.AddAsync(new FlightCompany { Name = "Bulgaria Air" });

            await dbContext.SaveChangesAsync();
        }
    }
}
