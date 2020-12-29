namespace TravelPointSystem.Services.Data.Tests.Common.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TravelPointSystem.Data;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;

    public class HotelsServiceTestsSeeder
    {
        public async Task SeedHotelAsync(ApplicationDbContext context)
        {
            var hotel = new Hotel
            {
                Name = "HotelName",
                ImageUrl = "ImageUrl",
                Description = "Description",
                Address = "Adress",
                DestinationId = 1,
                PricePerNightPerPerson = 50,
                Stars = 1,
                AvailableRooms = 1,
                FeedingType = FeedingType.Breakfast,
                ReservationType = ReservationType.Hotel,

            };

            await context.Hotels.AddAsync(hotel);
            await context.SaveChangesAsync();
        }
    }
}
