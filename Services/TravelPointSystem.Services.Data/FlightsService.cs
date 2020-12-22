namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Flights;

    public class FlightsService : IFlightsService
    {
        private readonly IDeletableEntityRepository<Flight> flightsRepository;

        public FlightsService(IDeletableEntityRepository<Flight> flightsRepository)
        {
            this.flightsRepository = flightsRepository;
        }

        public async Task CreateAsync(FlightInputModel inputModel)
        {
            var flight = new Flight
            {
                FlightNumber = inputModel.FlightNumber,
                PricePerPerson = inputModel.PricePerPerson,
                CompanyId = inputModel.CompanyId,
                DepartureDateTime = inputModel.DepartureDateTime,
                FlightTime = inputModel.FlightTime,
                StartPointId = inputModel.StartPointId,
                StartPointAirPort = inputModel.StartPointAirPort,
                EndPointId = inputModel.EndPointId,
                EndPointAirPort = inputModel.EndPointAirPort,
                AvailableSeats = inputModel.AvailableSeats,
                ReservationType = inputModel.ReservationType,
            };

            await this.flightsRepository.AddAsync(flight);
            await this.flightsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var flight = await this.flightsRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.flightsRepository.Delete(flight);

            await this.flightsRepository.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            return this.flightsRepository.All().Select(x => new
            {
                x.Id,
                x.FlightNumber,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.FlightNumber)).OrderBy(x => x.Value);
        }

        public async Task<IEnumerable<FlightViewModel>> GetAllAsync()
        {
            var flights = await this.flightsRepository.All().OrderBy(x => x.FlightNumber).To<FlightViewModel>().ToListAsync();

            return flights;
        }

        public async Task<IEnumerable<FlightViewModel>> GetAllByDestinationsIdAsync(int startDestinationId, int endDestinationId)
        {
            return await this.flightsRepository.All()
                .Where(x => x.StartPointId == startDestinationId && x.EndPointId == endDestinationId)
                .OrderBy(x => x.FlightNumber)
                .To<FlightViewModel>()
                .ToListAsync();
        }

        public async Task<FlightViewModel> GetByIdAsync(string id)
        {
            var flight = await this.flightsRepository.All()
                .Where(x => x.Id == id)
                .To<FlightViewModel>().FirstOrDefaultAsync();

            return flight;
        }
    }
}
