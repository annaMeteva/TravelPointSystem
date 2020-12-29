namespace TravelPointSystem.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Moq;
    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Data.Repositories;
    using TravelPointSystem.Services.Data.Tests.Common;
    using TravelPointSystem.Services.Data.Tests.Common.Seeders;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Buses;
    using Xunit;

    public class BusesServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShouldSuccessfullyAddToDatabase()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var busRepository = new EfDeletableEntityRepository<Bus>(context);

            var service = new BusesService(busRepository);
            var inputModel = new BusInputModel();
            inputModel.BusNumber = "BusNumber";
            inputModel.AvailableSeats = 20;
            inputModel.PricePerPerson = 50;
            inputModel.ReservationType = ReservationType.Bus;
            inputModel.StartPointId = 1;
            inputModel.StartPointStation = "StartStation";
            inputModel.EndPointId = 2;
            inputModel.EndPointStation = "EndStation";
            inputModel.DepartureDateTime = new DateTime(2020, 03, 03, 13, 00, 00);
            inputModel.TravellingTime = new TimeSpan(30, 30, 00);

            var expectedResult = 1;

            // Act
            await service.CreateAsync(inputModel);
            var actualResult = busRepository.All().Count();

            // Assert
            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task EditAsync_ShouldWorkCorrectly()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new BusesServiceTestsSeeder();
            await seeder.SeedBusAsync(context);
            var busRepository = new EfDeletableEntityRepository<Bus>(context);

            var service = new BusesService(busRepository);
            var bus = busRepository.All().First();
            var model = new BusViewModel
            {
                Id = bus.Id,
                BusNumber = bus.BusNumber,
                AvailableSeats = bus.AvailableSeats,
                PricePerPerson = bus.PricePerPerson,
                ReservationType = bus.ReservationType,
                StartPointId = bus.StartPointId,
                StartPointStation = bus.StartPointStation,
                EndPointId = bus.EndPointId,
                EndPointStation = bus.EndPointStation,
                DepartureDateTime = bus.DepartureDateTime,
                TravellingTime = bus.TravellingTime,
            };

            model.BusNumber = "EditedBusNumber";
            model.AvailableSeats = 20;
            model.PricePerPerson = 50;
            model.ReservationType = ReservationType.Bus;
            model.StartPointId = 1;
            model.StartPointStation = "EditedStartStation";
            model.EndPointId = 2;
            model.EndPointStation = "EditedEndStation";
            model.DepartureDateTime = new DateTime(2020, 03, 03, 13, 00, 00);
            model.TravellingTime = new TimeSpan(30, 30, 00);

            // Act
            await service.EditAsync(model.Id, model);
            var actualResult = busRepository.All().First();
            var expectedResult = model;

            // Assert
            Assert.True(expectedResult.BusNumber == actualResult.BusNumber);
            Assert.True(expectedResult.AvailableSeats == actualResult.AvailableSeats);
            Assert.True(expectedResult.PricePerPerson == actualResult.PricePerPerson);
            Assert.True(expectedResult.ReservationType == actualResult.ReservationType);
            Assert.True(expectedResult.StartPointId == actualResult.StartPointId);
            Assert.True(expectedResult.StartPointStation == actualResult.StartPointStation);
            Assert.True(expectedResult.EndPointId == actualResult.EndPointId);
            Assert.True(expectedResult.EndPointStation == actualResult.EndPointStation);
            Assert.True(expectedResult.DepartureDateTime == actualResult.DepartureDateTime);
            Assert.True(expectedResult.TravellingTime == actualResult.TravellingTime);
        }

        [Fact]
        public async Task DeleteAsync_ShouldSuccessfullyDelete()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new BusesServiceTestsSeeder();
            await seeder.SeedBusAsync(context);
            var busRepository = new EfDeletableEntityRepository<Bus>(context);

            var service = new BusesService(busRepository);
            var busId = busRepository.All().First().Id;

            // Act
            var busesCount = busRepository.All().Count();
            await service.DeleteAsync(busId);
            var actualResult = busRepository.All().Count();
            var expectedResult = busesCount - 1;

            // Assert
            Assert.True(actualResult == expectedResult);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectResult()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new BusesServiceTestsSeeder();
            await seeder.SeedBusAsync(context);
            var busRepository = new EfDeletableEntityRepository<Bus>(context);

            var service = new BusesService(busRepository);
            var busId = busRepository.All().First().Id;

            // Act
            var actualResult = await service.GetByIdAsync(busId);
            var expectedResult = await busRepository
                .All().To<BusViewModel>()
                .FirstOrDefaultAsync(x => x.Id == busId);

            // Assert
            Assert.True(actualResult.Id == expectedResult.Id);
            Assert.True(expectedResult.BusNumber == actualResult.BusNumber);
            Assert.True(expectedResult.AvailableSeats == actualResult.AvailableSeats);
            Assert.True(expectedResult.PricePerPerson == actualResult.PricePerPerson);
            Assert.True(expectedResult.ReservationType == actualResult.ReservationType);
            Assert.True(expectedResult.StartPointId == actualResult.StartPointId);
            Assert.True(expectedResult.StartPointStation == actualResult.StartPointStation);
            Assert.True(expectedResult.EndPointId == actualResult.EndPointId);
            Assert.True(expectedResult.EndPointStation == actualResult.EndPointStation);
            Assert.True(expectedResult.DepartureDateTime == actualResult.DepartureDateTime);
            Assert.True(expectedResult.TravellingTime == actualResult.TravellingTime);
        }

        [Fact]
        public async Task IsExistingMethod_ShouldReturnTrueIfBusExists()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new BusesServiceTestsSeeder();
            await seeder.SeedBusAsync(context);
            var busRepository = new EfDeletableEntityRepository<Bus>(context);

            var service = new BusesService(busRepository);
            var busId = busRepository.All().First().Id;

            // Act
            var actualResult = service.Exists(busId);
            var expectedResult = true;

            // Assert
            Assert.True(actualResult == expectedResult);
        }

        [Fact]
        public async Task IsExistingMethod_ShouldReturnFalseIfFlightNotExists()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new BusesServiceTestsSeeder();
            await seeder.SeedBusAsync(context);
            var busRepository = new EfDeletableEntityRepository<Bus>(context);

            var service = new BusesService(busRepository);

            // Act
            var actualResult = service.Exists("BusId");
            var expectedResult = false;

            // Assert
            Assert.True(actualResult == expectedResult);
        }
    }
}
