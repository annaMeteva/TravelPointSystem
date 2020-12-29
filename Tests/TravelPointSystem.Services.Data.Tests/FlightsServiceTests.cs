namespace TravelPointSystem.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Data.Repositories;
    using TravelPointSystem.Services.Data.Tests.Common;
    using TravelPointSystem.Services.Data.Tests.Common.Seeders;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Flights;
    using Xunit;

    public class FlightsServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShouldSuccessfullyAddToDatabase()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var flightRepository = new EfDeletableEntityRepository<Flight>(context);

            var service = new FlightsService(flightRepository);
            var inputModel = new FlightInputModel();
            inputModel.FlightNumber = "FlightNumber";
            inputModel.AvailableSeats = 20;
            inputModel.PricePerPerson = 50;
            inputModel.ReservationType = ReservationType.Flight;
            inputModel.StartPointId = 1;
            inputModel.StartPointAirPort = "StartAirPort";
            inputModel.EndPointId = 2;
            inputModel.EndPointAirPort = "EndAirPort";
            inputModel.DepartureDateTime = new DateTime(2020, 03, 03, 13, 00, 00);
            inputModel.FlightTime = new TimeSpan(30, 30, 00);
            inputModel.CompanyId = 1;

            var expectedResult = 1;

            // Act
            await service.CreateAsync(inputModel);
            var actualResult = flightRepository.All().Count();

            // Assert
            Assert.True(expectedResult == actualResult);
        }

        [Fact]
        public async Task EditAsync_ShouldWorkCorrectly()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new FlightsServiceTestsSeeder();
            await seeder.SeedFlightAsync(context);
            var flightRepository = new EfDeletableEntityRepository<Flight>(context);

            var service = new FlightsService(flightRepository);
            var flight = flightRepository.All().First();
            var model = new FlightViewModel
            {
                Id = flight.Id,
                FlightNumber = flight.FlightNumber,
                AvailableSeats = flight.AvailableSeats,
                PricePerPerson = flight.PricePerPerson,
                ReservationType = flight.ReservationType,
                StartPointId = flight.StartPointId,
                StartPointAirPort = flight.StartPointAirPort,
                EndPointId = flight.EndPointId,
                EndPointAirPort = flight.EndPointAirPort,
                DepartureDateTime = flight.DepartureDateTime,
                FlightTime = flight.FlightTime,
                CompanyId = flight.CompanyId,
            };

            model.FlightNumber = "EditedFlightNumber";
            model.AvailableSeats = 20;
            model.PricePerPerson = 50;
            model.ReservationType = ReservationType.Flight;
            model.StartPointId = 1;
            model.StartPointAirPort = "EditedStartAirPort";
            model.EndPointId = 2;
            model.EndPointAirPort = "EditedEndAirPort";
            model.DepartureDateTime = new DateTime(2020, 03, 03, 13, 00, 00);
            model.FlightTime = new TimeSpan(30, 30, 00);
            model.CompanyId = 1;

            // Act
            await service.EditAsync(model.Id, model);
            var actualResult = flightRepository.All().First();
            var expectedResult = model;

            // Assert
            Assert.True(expectedResult.FlightNumber == actualResult.FlightNumber);
            Assert.True(expectedResult.AvailableSeats == actualResult.AvailableSeats);
            Assert.True(expectedResult.PricePerPerson == actualResult.PricePerPerson);
            Assert.True(expectedResult.ReservationType == actualResult.ReservationType);
            Assert.True(expectedResult.StartPointId == actualResult.StartPointId);
            Assert.True(expectedResult.StartPointAirPort == actualResult.StartPointAirPort);
            Assert.True(expectedResult.EndPointId == actualResult.EndPointId);
            Assert.True(expectedResult.EndPointAirPort == actualResult.EndPointAirPort);
            Assert.True(expectedResult.DepartureDateTime == actualResult.DepartureDateTime);
            Assert.True(expectedResult.FlightTime == actualResult.FlightTime);
            Assert.True(expectedResult.CompanyId == actualResult.CompanyId);
        }

        [Fact]
        public async Task DeleteAsync_ShouldSuccessfullyDelete()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new FlightsServiceTestsSeeder();
            await seeder.SeedFlightAsync(context);
            var flightRepository = new EfDeletableEntityRepository<Flight>(context);

            var service = new FlightsService(flightRepository);
            var flightId = flightRepository.All().First().Id;

            // Act
            var flightsCount = flightRepository.All().Count();
            await service.DeleteAsync(flightId);
            var actualResult = flightRepository.All().Count();
            var expectedResult = flightsCount - 1;

            // Assert
            Assert.True(actualResult == expectedResult);
        }

        [Fact]
        public async Task IsExistingMethod_ShouldReturnTrueIfFlightExists()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new FlightsServiceTestsSeeder();
            await seeder.SeedFlightAsync(context);
            var flightRepository = new EfDeletableEntityRepository<Flight>(context);

            var service = new FlightsService(flightRepository);
            var flightId = flightRepository.All().First().Id;

            // Act
            var actualResult = service.Exists(flightId);
            var expectedResult = true;

            // Assert
            Assert.True(actualResult == expectedResult);
        }

        [Fact]
        public async Task IsExistingMethod_ShouldReturnFalseIfFlightNotExists()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new FlightsServiceTestsSeeder();
            await seeder.SeedFlightAsync(context);
            var flightRepository = new EfDeletableEntityRepository<Flight>(context);

            var service = new FlightsService(flightRepository);

            // Act
            var actualResult = service.Exists("FlightId");
            var expectedResult = false;

            // Assert
            Assert.True(actualResult == expectedResult);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCorrectResult()
        {
            // Arrange
            var context = ApplicationDbContextInMemoryFactory.InitializeContext();
            var seeder = new FlightsServiceTestsSeeder();
            await seeder.SeedFlightAsync(context);
            var flightRepository = new EfDeletableEntityRepository<Flight>(context);

            var service = new FlightsService(flightRepository);
            var flightId = flightRepository.All().First().Id;

            // Act
            var actualResult = await service.GetByIdAsync(flightId);
            var expectedResult = await flightRepository
                .All().To<FlightViewModel>()
                .FirstOrDefaultAsync(x => x.Id == flightId);

            // Assert
            Assert.True(actualResult.Id == expectedResult.Id);
            Assert.True(expectedResult.FlightNumber == actualResult.FlightNumber);
            Assert.True(expectedResult.AvailableSeats == actualResult.AvailableSeats);
            Assert.True(expectedResult.PricePerPerson == actualResult.PricePerPerson);
            Assert.True(expectedResult.ReservationType == actualResult.ReservationType);
            Assert.True(expectedResult.StartPointId == actualResult.StartPointId);
            Assert.True(expectedResult.StartPointAirPort == actualResult.StartPointAirPort);
            Assert.True(expectedResult.EndPointId == actualResult.EndPointId);
            Assert.True(expectedResult.EndPointAirPort == actualResult.EndPointAirPort);
            Assert.True(expectedResult.DepartureDateTime == actualResult.DepartureDateTime);
            Assert.True(expectedResult.FlightTime == actualResult.FlightTime);
            Assert.True(expectedResult.CompanyId == actualResult.CompanyId);
        }
    }
}
