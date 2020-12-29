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
    using TravelPointSystem.Web.ViewModels.OrganizedTrips;
    using Xunit;

    public class OrganizedTripsServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShouldSuccessfullyAddToDatabase()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var tripRepository = new EfDeletableEntityRepository<OrganizedTrip>(context);

            var service = new OrganizedTripsService(tripRepository);
            var inputModel = new OrganizedTripInputModel();
            inputModel.Name = "HotelName";
            inputModel.ImageUrl = "ImageUrl";
            inputModel.Description = "Description";
            inputModel.DepartureDateTime = new DateTime(2020, 03, 03, 13, 00, 00);
            inputModel.ReturnDateTime = new DateTime(2020, 03, 03, 13, 30, 00);
            inputModel.DestinationId = 1;
            inputModel.PricePerPerson = 0;
            inputModel.HotelId = 1;
            inputModel.AvailableSeats = 1;
            inputModel.Transport = TransportType.Flight;
            inputModel.ReservationType = ReservationType.OrganizedTrip;

            var expectedResult = 1;

            // Act
            await service.CreateAsync(inputModel);
            var actualResult = tripRepository.All().Count();

            // Assert
            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task EditAsync_ShouldWorkCorrectly()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new OrganizedtripsServiceTestsSeeder();
            await seeder.SeedTripAsync(context);
            var tripRepository = new EfDeletableEntityRepository<OrganizedTrip>(context);

            var service = new OrganizedTripsService(tripRepository);
            var trip = tripRepository.All().First();
            var model = new OrganizedTripViewModel
            {
                Id = trip.Id,
                Name = trip.Name,
                ImageUrl = trip.ImageUrl,
                Description = trip.Description,
                DepartureDateTime = trip.DepartureDateTime,
                ReturnDateTime = trip.ReturnDateTime,
                DestinationId = trip.DestinationId,
                PricePerPerson = trip.PricePerPerson,
                HotelId = trip.HotelId,
                AvailableSeats = trip.AvailableSeats,
                Transport = trip.Transport,
                ReservationType = trip.ReservationType,
            };

            model.Name = "EditedTripName";
            model.ImageUrl = "EditedImageUrl";
            model.PricePerPerson = 50;
            model.ReservationType = ReservationType.OrganizedTrip;
            model.Description = "EditedDescription";
            model.DepartureDateTime = new DateTime(2020, 03, 03, 13, 00, 00);
            model.ReturnDateTime = new DateTime(2020, 03, 03, 13, 30, 00);
            model.DestinationId = 1;
            model.HotelId = 1;
            model.AvailableSeats = 2;
            model.Transport = TransportType.Bus;

            // Act
            await service.EditAsync(model.Id, model);
            var actualResult = tripRepository.All().First();
            var expectedResult = model;

            // Assert
            Assert.True(expectedResult.Name == actualResult.Name);
            Assert.True(expectedResult.ImageUrl == actualResult.ImageUrl);
            Assert.True(expectedResult.Description == actualResult.Description);
            Assert.True(expectedResult.ReservationType == actualResult.ReservationType);
            Assert.True(expectedResult.PricePerPerson == actualResult.PricePerPerson);
            Assert.True(expectedResult.DepartureDateTime == actualResult.DepartureDateTime);
            Assert.True(expectedResult.ReturnDateTime == actualResult.ReturnDateTime);
            Assert.True(expectedResult.AvailableSeats == actualResult.AvailableSeats);
            Assert.True(expectedResult.HotelId == actualResult.HotelId);
            Assert.True(expectedResult.Transport == actualResult.Transport);
            Assert.True(expectedResult.DestinationId == actualResult.DestinationId);
        }

        [Fact]
        public async Task DeleteAsync_ShouldSuccessfullyDelete()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new OrganizedtripsServiceTestsSeeder();
            await seeder.SeedTripAsync(context);
            var tripRepository = new EfDeletableEntityRepository<OrganizedTrip>(context);

            var service = new OrganizedTripsService(tripRepository);
            var tripId = tripRepository.All().First().Id;

            // Act
            var tripsCount = tripRepository.All().Count();
            await service.DeleteAsync(tripId);
            var actualResult = tripRepository.All().Count();
            var expectedResult = tripsCount - 1;

            // Assert
            Assert.True(actualResult == expectedResult);
        }

        [Fact]
        public async Task IsExistingMethod_ShouldReturnTrueIfFlightExists()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new OrganizedtripsServiceTestsSeeder();
            await seeder.SeedTripAsync(context);
            var tripRepository = new EfDeletableEntityRepository<OrganizedTrip>(context);

            var service = new OrganizedTripsService(tripRepository);
            var tripId = tripRepository.All().First().Id;

            // Act
            var actualResult = service.Exists(tripId);
            var expectedResult = true;

            // Assert
            Assert.True(actualResult == expectedResult);
        }

        [Fact]
        public async Task IsExistingMethod_ShouldReturnFalseIfFlightNotExists()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new OrganizedtripsServiceTestsSeeder();
            await seeder.SeedTripAsync(context);
            var tripRepository = new EfDeletableEntityRepository<OrganizedTrip>(context);

            var service = new OrganizedTripsService(tripRepository);

            // Act
            var actualResult = service.Exists("TripId");
            var expectedResult = false;

            // Assert
            Assert.True(actualResult == expectedResult);
        }
    }
}
