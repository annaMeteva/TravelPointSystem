namespace TravelPointSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;

    public class OrganizedTripsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.OrganizedTrips.Any())
            {
                return;
            }

            await dbContext.OrganizedTrips.AddAsync(new OrganizedTrip { Name = "To Italy and back", PricePerPerson = 700.0, DepartureDateTime = new DateTime(2021, 3, 23, 12, 30, 0), ReturnDateTime = new DateTime(2021, 3, 28, 13, 0, 0), Transport = TransportType.Flight, AvailableSeats = 10, DestinationId = dbContext.Destinations.Single(d => d.Town == "Rome").Id, HotelId = dbContext.Hotels.Single(h => h.Name == "Otivm Hotel").Id });
            await dbContext.OrganizedTrips.AddAsync(new OrganizedTrip { Name = "To Germany and back", PricePerPerson = 400.0, DepartureDateTime = new DateTime(2021, 2, 3, 14, 15, 0), ReturnDateTime = new DateTime(2021, 2, 10, 13, 0, 0), Transport = TransportType.Flight, AvailableSeats = 10, DestinationId = dbContext.Destinations.Single(d => d.Town == "Brussels").Id, HotelId = dbContext.Hotels.Single(h => h.Name == "Aparthotel Adagio").Id });
            await dbContext.OrganizedTrips.AddAsync(new OrganizedTrip { Name = "To France and back", PricePerPerson = 800.0, DepartureDateTime = new DateTime(2021, 1, 25, 6, 30, 0), ReturnDateTime = new DateTime(2021, 2, 1, 13, 0, 0), Transport = TransportType.Flight, AvailableSeats = 10, DestinationId = dbContext.Destinations.Single(d => d.Town == "Paris").Id, HotelId = dbContext.Hotels.Single(h => h.Name == "Hotel Paris Lafayette").Id });
            await dbContext.OrganizedTrips.AddAsync(new OrganizedTrip { Name = "To Spain and back", PricePerPerson = 500.0, DepartureDateTime = new DateTime(2021, 2, 14, 10, 40, 0), ReturnDateTime = new DateTime(2021, 2, 20, 13, 0, 0), Transport = TransportType.Flight, AvailableSeats = 10, DestinationId = dbContext.Destinations.Single(d => d.Town == "Madrid").Id, HotelId = dbContext.Hotels.Single(h => h.Name == "Radisson Blu Hotel").Id });
            await dbContext.OrganizedTrips.AddAsync(new OrganizedTrip { Name = "Vienna treasures", PricePerPerson = 350.0, DepartureDateTime = new DateTime(2021, 1, 5, 12, 30, 0), ReturnDateTime = new DateTime(2021, 1, 12, 13, 0, 0), Transport = TransportType.Bus, AvailableSeats = 10, DestinationId = dbContext.Destinations.Single(d => d.Town == "Vienna").Id, HotelId = dbContext.Hotels.Single(h => h.Name == "Hilton Vienna Plaza").Id });

            await dbContext.SaveChangesAsync();
        }
    }
}
