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

            await dbContext.OrganizedTrips.AddAsync(new OrganizedTrip { Name = "To Italy and back", PricePerPerson = 700.0, DepartureDateTime = new DateTime(2021, 3, 23, 12, 30, 0), ReturnDateTime = new DateTime(2021, 3, 28, 13, 0, 0), Transport = TransportType.Flight, AvailableSeats = 10, DestinationId = dbContext.Destinations.Single(d => d.Town == "Rome").Id, HotelId = dbContext.Hotels.Single(h => h.Name == "Otivm Hotel").Id, ImageUrl = "https://www.fodors.com/wp-content/uploads/2018/10/HERO_UltimateRome_Hero_shutterstock789412159.jpg", Description = "Rome was called the “Eternal City” by the ancient Romans because they believed that no matter what happened in the rest of the world, the city of Rome would always remain standing. Exploring the city centre by foot surrounded by glorious monuments and colossal remains takes you back in time to the “glory that was Rome”.", ReservationType = ReservationType.OrganizedTrip });
            await dbContext.OrganizedTrips.AddAsync(new OrganizedTrip { Name = "To Germany and back", PricePerPerson = 400.0, DepartureDateTime = new DateTime(2021, 2, 3, 14, 15, 0), ReturnDateTime = new DateTime(2021, 2, 10, 13, 0, 0), Transport = TransportType.Flight, AvailableSeats = 10, DestinationId = dbContext.Destinations.Single(d => d.Town == "Brussels").Id, HotelId = dbContext.Hotels.Single(h => h.Name == "Aparthotel Adagio").Id, ImageUrl = "https://lp-cms-production.imgix.net/2019-06/99226269.jpg", Description = "Take advantage of our Brussels bargain holidays and make memories you'll cherish forever. Whether you party all night or just relax and unwind, nothing beats a change of scene and making new friends.", ReservationType = ReservationType.OrganizedTrip });
            await dbContext.OrganizedTrips.AddAsync(new OrganizedTrip { Name = "To France and back", PricePerPerson = 800.0, DepartureDateTime = new DateTime(2021, 1, 25, 6, 30, 0), ReturnDateTime = new DateTime(2021, 2, 1, 13, 0, 0), Transport = TransportType.Flight, AvailableSeats = 10, DestinationId = dbContext.Destinations.Single(d => d.Town == "Paris").Id, HotelId = dbContext.Hotels.Single(h => h.Name == "Hotel Paris Lafayette").Id, ImageUrl = "https://www.telegraph.co.uk/content/dam/Travel/hotels/europe/france/paris/paris-cityscape-overview-guide.jpg", Description = "Whether you're looking  to embark on a romantic getaway or simply wanting to explore one of Europe's most popular destinations, Paris makes for an ideal mini-holiday. The city's maze of cobbled backstreets and grand, sweeping avenues are a delight to explore. In addition to some of the Notre Dame and many more - be sure to explore the Left Bank by night, where great dining and entertainment options abound. ", ReservationType = ReservationType.OrganizedTrip });
            await dbContext.OrganizedTrips.AddAsync(new OrganizedTrip { Name = "To Spain and back", PricePerPerson = 500.0, DepartureDateTime = new DateTime(2021, 2, 14, 10, 40, 0), ReturnDateTime = new DateTime(2021, 2, 20, 13, 0, 0), Transport = TransportType.Flight, AvailableSeats = 10, DestinationId = dbContext.Destinations.Single(d => d.Town == "Madrid").Id, HotelId = dbContext.Hotels.Single(h => h.Name == "Radisson Blu Hotel").Id, ImageUrl = "https://www.polisnetwork.eu/wp-content/uploads/2011/03/Madrid-Jorge-Fernandez-Salas.jpg", Description = "Philip II first chose Madrid as the capital of Spain because of its privileged location in the centre of the Iberian Peninsula. And when you come to Madrid, you will discover just how easy it is to travel from here to the rest of the country. No Spanish town is more than 8 hours from Madrid, and the AVE high-speed train has made it even easier to travel around the country.", ReservationType = ReservationType.OrganizedTrip });
            await dbContext.OrganizedTrips.AddAsync(new OrganizedTrip { Name = "Vienna's treasures", PricePerPerson = 350.0, DepartureDateTime = new DateTime(2021, 1, 5, 12, 30, 0), ReturnDateTime = new DateTime(2021, 1, 12, 13, 0, 0), Transport = TransportType.Bus, AvailableSeats = 10, DestinationId = dbContext.Destinations.Single(d => d.Town == "Vienna").Id, HotelId = dbContext.Hotels.Single(h => h.Name == "Hilton Vienna Plaza").Id, ImageUrl = "https://www.telegraph.co.uk/content/dam/Travel/Destinations/Europe/Austria/Vienna/st-stephen-s-cathedral-vienna-p.jpg", Description = "The only capital city in the world that produces its own branded wine, Vienna is highly praised for its fine Rococo and Baroque architecture, and classical music heritage. Indeed, the flourishing Austrian capital is the birthplace of some of the world's most distinguished composers, from Schubert to Mozart, and was, for almost eight decades, the home of Sigmund Freud.", ReservationType = ReservationType.OrganizedTrip });

            await dbContext.SaveChangesAsync();
        }
    }
}
