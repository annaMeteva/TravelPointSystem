namespace TravelPointSystem.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Data.Repositories;
    using TravelPointSystem.Services.Data.Tests.Common;
    using TravelPointSystem.Services.Data.Tests.Common.Seeders;
    using TravelPointSystem.Web.ViewModels.Hotels;
    using Xunit;

    public class HotelsServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShouldSuccessfullyAddToDatabase()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var hotelRepository = new EfDeletableEntityRepository<Hotel>(context);

            var service = new HotelsService(hotelRepository);
            var inputModel = new HotelInputModel();
            inputModel.Name = "HotelName";
            inputModel.ImageUrl = "ImageUrl";
            inputModel.Description = "Description";
            inputModel.Address = "Adress";
            inputModel.DestinationId = 1;
            inputModel.PricePerNightPerPerson = 0;
            inputModel.Stars = 1;
            inputModel.AvailableRooms = 1;
            inputModel.FeedingType = FeedingType.Breakfast;
            inputModel.ReservationType = ReservationType.Hotel;

            var expectedResult = 1;

            // Act
            await service.CreateAsync(inputModel);
            var actualResult = hotelRepository.All().Count();

            // Assert
            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task EditAsync_ShouldWorkCorrectly()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new HotelsServiceTestsSeeder();
            await seeder.SeedHotelAsync(context);
            var hotelRepository = new EfDeletableEntityRepository<Hotel>(context);

            var service = new HotelsService(hotelRepository);
            var hotel = hotelRepository.All().First();
            var model = new HotelViewModel
            {
                Id = hotel.Id,
                Name = hotel.Name,
                ImageUrl = hotel.ImageUrl,
                Description = hotel.Description,
                Address = hotel.Address,
                DestinationId = hotel.DestinationId,
                PricePerNightPerPerson = hotel.PricePerNightPerPerson,
                Stars = hotel.Stars,
                AvailableRooms = hotel.AvailableRooms,
                FeedingType = hotel.FeedingType,
                ReservationType = hotel.ReservationType,
            };

            model.Name = "EditedHotelName";
            model.ImageUrl = "EditedImageUrl";
            model.PricePerNightPerPerson = 50;
            model.ReservationType = ReservationType.Hotel;
            model.Description = "EditedDescription";
            model.Address = "EditedAddress";
            model.DestinationId = 1;
            model.Stars = 1;
            model.AvailableRooms = 2;
            model.FeedingType = FeedingType.HalfBoard;

            // Act
            await service.EditAsync(model.Id, model);
            var actualResult = hotelRepository.All().First();
            var expectedResult = model;

            // Assert
            Assert.True(expectedResult.Name == actualResult.Name);
            Assert.True(expectedResult.ImageUrl == actualResult.ImageUrl);
            Assert.True(expectedResult.Description == actualResult.Description);
            Assert.True(expectedResult.ReservationType == actualResult.ReservationType);
            Assert.True(expectedResult.PricePerNightPerPerson == actualResult.PricePerNightPerPerson);
            Assert.True(expectedResult.Address == actualResult.Address);
            Assert.True(expectedResult.AvailableRooms == actualResult.AvailableRooms);
            Assert.True(expectedResult.Stars == actualResult.Stars);
            Assert.True(expectedResult.FeedingType == actualResult.FeedingType);
            Assert.True(expectedResult.DestinationId == actualResult.DestinationId);
        }

        [Fact]
        public async Task DeleteAsync_ShouldSuccessfullyDelete()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new HotelsServiceTestsSeeder();
            await seeder.SeedHotelAsync(context);
            var hotelRepository = new EfDeletableEntityRepository<Hotel>(context);

            var service = new HotelsService(hotelRepository);
            var hotelId = hotelRepository.All().First().Id;

            // Act
            var hotelsCount = hotelRepository.All().Count();
            await service.DeleteAsync(hotelId);
            var actualResult = hotelRepository.All().Count();
            var expectedResult = hotelsCount - 1;

            // Assert
            Assert.True(actualResult == expectedResult);
        }

        [Fact]
        public async Task IsExistingMethod_ShouldReturnTrueIfFlightExists()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new HotelsServiceTestsSeeder();
            await seeder.SeedHotelAsync(context);
            var hotelRepository = new EfDeletableEntityRepository<Hotel>(context);

            var service = new HotelsService(hotelRepository);
            var hotelId = hotelRepository.All().First().Id;

            // Act
            var actualResult = service.Exists(hotelId);
            var expectedResult = true;

            // Assert
            Assert.True(actualResult == expectedResult);
        }

        [Fact]
        public async Task IsExistingMethod_ShouldReturnFalseIfFlightNotExists()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new HotelsServiceTestsSeeder();
            await seeder.SeedHotelAsync(context);
            var hotelRepository = new EfDeletableEntityRepository<Hotel>(context);

            var service = new HotelsService(hotelRepository);

            // Act
            var actualResult = service.Exists(2);
            var expectedResult = false;

            // Assert
            Assert.True(actualResult == expectedResult);
        }
    }
}
