namespace TravelPointSystem.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;

    public class HotelsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Hotels.Any())
            {
                return;
            }

            await dbContext.Hotels.AddAsync(new Hotel { Name = "Hilton Vienna Danube Waterfront", DestinationId = dbContext.Destinations.Single(d => d.Town == "Vienna").Id, PricePerNightPerPerson = 70.0, Stars = 4, FeedingType = FeedingType.HalfBoard });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Motel One Wien-Staatsoper", DestinationId = dbContext.Destinations.Single(d => d.Town == "Vienna").Id, PricePerNightPerPerson = 40.0, Stars = 3, FeedingType = FeedingType.Breakfast });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Hilton Vienna Plaza", DestinationId = dbContext.Destinations.Single(d => d.Town == "Vienna").Id, PricePerNightPerPerson = 120.0, Stars = 5, FeedingType = FeedingType.AllInclusive });


            await dbContext.Hotels.AddAsync(new Hotel { Name = "Safestay Brussels", DestinationId = dbContext.Destinations.Single(d => d.Town == "Brussels").Id, PricePerNightPerPerson = 43.0, Stars = 2, FeedingType = FeedingType.Breakfast });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Gresham Belson Hotel", DestinationId = dbContext.Destinations.Single(d => d.Town == "Brussels").Id, PricePerNightPerPerson = 55.0, Stars = 4, FeedingType = FeedingType.HalfBoard });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Aparthotel Adagio", DestinationId = dbContext.Destinations.Single(d => d.Town == "Brussels").Id, PricePerNightPerPerson = 46.0, Stars = 2, FeedingType = FeedingType.Breakfast });


            await dbContext.Hotels.AddAsync(new Hotel { Name = "Hotel Forum", DestinationId = dbContext.Destinations.Single(d => d.Town == "Sofia").Id, PricePerNightPerPerson = 30.0, Stars = 3, FeedingType = FeedingType.Breakfast });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "InterContinental Hotel", DestinationId = dbContext.Destinations.Single(d => d.Town == "Sofia").Id, PricePerNightPerPerson = 92.0, Stars = 5, FeedingType = FeedingType.AllInclusive });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Best Western Plus Bristol Hotel", DestinationId = dbContext.Destinations.Single(d => d.Town == "Sofia").Id, PricePerNightPerPerson = 50.0, Stars = 4, FeedingType = FeedingType.HalfBoard });


            await dbContext.Hotels.AddAsync(new Hotel { Name = "Palace Hotel", DestinationId = dbContext.Destinations.Single(d => d.Town == "Zagreb").Id, PricePerNightPerPerson = 44.0, Stars = 4, FeedingType = FeedingType.Breakfast });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Sheraton Zagreb Hotel", DestinationId = dbContext.Destinations.Single(d => d.Town == "Zagreb").Id, PricePerNightPerPerson = 83.0, Stars = 5, FeedingType = FeedingType.HalfBoard });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Hotel Jadran", DestinationId = dbContext.Destinations.Single(d => d.Town == "Zagreb").Id, PricePerNightPerPerson = 30.0, Stars = 3, FeedingType = FeedingType.Breakfast });


            await dbContext.Hotels.AddAsync(new Hotel { Name = "Hilton Prague", DestinationId = dbContext.Destinations.Single(d => d.Town == "Prague").Id, PricePerNightPerPerson = 74.0, Stars = 5, FeedingType = FeedingType.FullBoard });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Grandium Hotel Prague", DestinationId = dbContext.Destinations.Single(d => d.Town == "Prague").Id, PricePerNightPerPerson = 47.0, Stars = 4, FeedingType = FeedingType.HalfBoard });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Grand Hotel Bohemia", DestinationId = dbContext.Destinations.Single(d => d.Town == "Prague").Id, PricePerNightPerPerson = 40.0, Stars = 5, FeedingType = FeedingType.Breakfast });


            await dbContext.Hotels.AddAsync(new Hotel { Name = "Mandarin Oriental", DestinationId = dbContext.Destinations.Single(d => d.Town == "Paris").Id, PricePerNightPerPerson = 500.0, Stars = 5, FeedingType = FeedingType.AllInclusive });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Hotel Paris Lafayette", DestinationId = dbContext.Destinations.Single(d => d.Town == "Paris").Id, PricePerNightPerPerson = 55.0, Stars = 3, FeedingType = FeedingType.Breakfast });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Hotel Ekta", DestinationId = dbContext.Destinations.Single(d => d.Town == "Paris").Id, PricePerNightPerPerson = 60.0, Stars = 3, FeedingType = FeedingType.Breakfast });


            await dbContext.Hotels.AddAsync(new Hotel { Name = "Park Inn by Radisson", DestinationId = dbContext.Destinations.Single(d => d.Town == "Berlin").Id, PricePerNightPerPerson = 80.0, Stars = 4, FeedingType = FeedingType.HalfBoard });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Hotel Riu Plaza", DestinationId = dbContext.Destinations.Single(d => d.Town == "Berlin").Id, PricePerNightPerPerson = 65.0, Stars = 4, FeedingType = FeedingType.Breakfast });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Enjoy Hotel", DestinationId = dbContext.Destinations.Single(d => d.Town == "Berlin").Id, PricePerNightPerPerson = 30.0, Stars = 3, FeedingType = FeedingType.Breakfast });

            await dbContext.Hotels.AddAsync(new Hotel { Name = "Central Hotel", DestinationId = dbContext.Destinations.Single(d => d.Town == "Athens").Id, PricePerNightPerPerson = 50.0, Stars = 3, FeedingType = FeedingType.Breakfast });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Grand Hyatt Athens", DestinationId = dbContext.Destinations.Single(d => d.Town == "Athens").Id, PricePerNightPerPerson = 95.0, Stars = 5, FeedingType = FeedingType.HalfBoard });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Electra Metropolis Athens", DestinationId = dbContext.Destinations.Single(d => d.Town == "Athens").Id, PricePerNightPerPerson = 120.0, Stars = 5, FeedingType = FeedingType.FullBoard });


            await dbContext.Hotels.AddAsync(new Hotel { Name = "Prestige Hotel Budapest", DestinationId = dbContext.Destinations.Single(d => d.Town == "Budapest").Id, PricePerNightPerPerson = 85.0, Stars = 4, FeedingType = FeedingType.HalfBoard });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Grand Hotel Jules Boat", DestinationId = dbContext.Destinations.Single(d => d.Town == "Budapest").Id, PricePerNightPerPerson = 30.0, Stars = 3, FeedingType = FeedingType.Breakfast });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Anabelle Bed and Breakfast Budapest", DestinationId = dbContext.Destinations.Single(d => d.Town == "Budapest").Id, PricePerNightPerPerson = 44.0, Stars = 4, FeedingType = FeedingType.Breakfast });


            await dbContext.Hotels.AddAsync(new Hotel { Name = "Otivm Hotel", DestinationId = dbContext.Destinations.Single(d => d.Town == "Rome").Id, PricePerNightPerPerson = 45.0, Stars = 4, FeedingType = FeedingType.Breakfast });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Palazzo Navona Hotel", DestinationId = dbContext.Destinations.Single(d => d.Town == "Rome").Id, PricePerNightPerPerson = 100.0, Stars = 4, FeedingType = FeedingType.FullBoard });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Ripetta Palace", DestinationId = dbContext.Destinations.Single(d => d.Town == "Rome").Id, PricePerNightPerPerson = 30.0, Stars = 1, FeedingType = FeedingType.Breakfast });


            await dbContext.Hotels.AddAsync(new Hotel { Name = "Central Palace Madrid", DestinationId = dbContext.Destinations.Single(d => d.Town == "Madrid").Id, PricePerNightPerPerson = 40.0, Stars = 3, FeedingType = FeedingType.Breakfast });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Radisson Blu Hotel", DestinationId = dbContext.Destinations.Single(d => d.Town == "Madrid").Id, PricePerNightPerPerson = 80.0, Stars = 4, FeedingType = FeedingType.HalfBoard });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Eurostars Madrid Tower", DestinationId = dbContext.Destinations.Single(d => d.Town == "Madrid").Id, PricePerNightPerPerson = 105.0, Stars = 1, FeedingType = FeedingType.HalfBoard });


            await dbContext.Hotels.AddAsync(new Hotel { Name = "Britannia International Hotel", DestinationId = dbContext.Destinations.Single(d => d.Town == "London").Id, PricePerNightPerPerson = 40.0, Stars = 4, FeedingType = FeedingType.Breakfast });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "London Hilton on Park Lane", DestinationId = dbContext.Destinations.Single(d => d.Town == "London").Id, PricePerNightPerPerson = 100.0, Stars = 5, FeedingType = FeedingType.HalfBoard });
            await dbContext.Hotels.AddAsync(new Hotel { Name = "Mornington Hotel London Victoria", DestinationId = dbContext.Destinations.Single(d => d.Town == "London").Id, PricePerNightPerPerson = 30.0, Stars = 4, FeedingType = FeedingType.Breakfast });

            await dbContext.SaveChangesAsync();
        }
    }
}
