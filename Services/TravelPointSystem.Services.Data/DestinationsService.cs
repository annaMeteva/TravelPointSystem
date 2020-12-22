namespace TravelPointSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Destinations;
    using TravelPointSystem.Web.ViewModels.Home;

    public class DestinationsService : IDestinationsService
    {
        private readonly IDeletableEntityRepository<Destination> destinationsRepository;
        private readonly IDeletableEntityRepository<Flight> flightsRepository;
        private readonly IDeletableEntityRepository<Hotel> hotelsRepository;
        private readonly IDeletableEntityRepository<OrganizedTrip> tripsRepository;
        private readonly IDeletableEntityRepository<Bus> busesRepository;

        public DestinationsService(IDeletableEntityRepository<Destination> destinationsRepository, IDeletableEntityRepository<Flight> flightsRepository, IDeletableEntityRepository<Hotel> hotelsRepository, IDeletableEntityRepository<OrganizedTrip> tripsRepository, IDeletableEntityRepository<Bus> busesRepository)
        {
            this.destinationsRepository = destinationsRepository;
            this.flightsRepository = flightsRepository;
            this.hotelsRepository = hotelsRepository;
            this.tripsRepository = tripsRepository;
            this.busesRepository = busesRepository;
        }

        public async Task CreateAsync(DestinationInputModel inputModel)
        {
            var destination = new Destination
            {
                Continent = inputModel.Continent,
                Country = inputModel.Country,
                Town = inputModel.Town,
            };

            await this.destinationsRepository.AddAsync(destination);
            await this.destinationsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            var destination = await this.destinationsRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            var flights = await this.flightsRepository.All()
                .Where(x => x.StartPointId == id || x.EndPointId == id).ToListAsync();

            var buses = await this.busesRepository.All()
               .Where(x => x.StartPointId == id || x.EndPointId == id).ToListAsync();

            var hotels = await this.hotelsRepository.All()
               .Where(x => x.DestinationId == id).ToListAsync();

            var trips = await this.tripsRepository.All()
               .Where(x => x.DestinationId == id).ToListAsync();

            foreach (var flight in flights)
            {
                this.flightsRepository.Delete(flight);
            }

            foreach (var bus in buses)
            {
                this.busesRepository.Delete(bus);
            }

            foreach (var hotel in hotels)
            {
                this.hotelsRepository.Delete(hotel);
            }

            foreach (var trip in trips)
            {
                this.tripsRepository.Delete(trip);
            }

            this.destinationsRepository.Delete(destination);

            await this.flightsRepository.SaveChangesAsync();
            await this.busesRepository.SaveChangesAsync();
            await this.hotelsRepository.SaveChangesAsync();
            await this.tripsRepository.SaveChangesAsync();

            await this.destinationsRepository.SaveChangesAsync();
        }

        public IEnumerable<DestinationViewModel> GetAll()
        {
            return this.destinationsRepository.All().OrderBy(x => x.Town).To<DestinationViewModel>();
        }

        public async Task<IEnumerable<DestinationViewModel>> GetAllAsync()
        {
            var destinations = await this.destinationsRepository.All().OrderBy(x => x.Continent).ThenBy(x => x.Country).ThenBy(x => x.Town).To<DestinationViewModel>().ToListAsync();

            return destinations;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCountriesForHotelsAsKeyValuePairs()
        {
            return this.destinationsRepository.All().Where(x => x.Hotels.Count != 0).Select(x => new
            {
                Key = x.Id,
                Value = string.Format("{0}, {1}", x.Town, x.Country),
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Key.ToString(), x.Value)).OrderBy(x => x.Value);
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllCountriesForTripsAsKeyValuePairs()
        {
            return this.destinationsRepository.All().Where(x => x.OrganizedTrips.Count != 0).Select(x => new
            {
                Key = x.Id,
                Value = string.Format("{0}, {1}", x.Town, x.Country),
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Key.ToString(), x.Value)).OrderBy(x => x.Value);
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllEndCountriesForBusesAsKeyValuePairs()
        {
            return this.destinationsRepository.All().Where(x => x.DepartingBuses.Count != 0).Select(x => new
            {
                Key = x.Id,
                Value = string.Format("{0}, {1}", x.Town, x.Country),
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Key.ToString(), x.Value)).OrderBy(x => x.Value);
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllEndCountriesForFlightsAsKeyValuePairs()
        {
            return this.destinationsRepository.All().Where(x => x.DepartingFlights.Count != 0).Select(x => new
            {
                Key = x.Id,
                Value = string.Format("{0}, {1}", x.Town, x.Country),
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Key.ToString(), x.Value)).OrderBy(x => x.Value);
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllStartCountriesForBusesAsKeyValuePairs()
        {
            return this.destinationsRepository.All().Where(x => x.DepartureBuses.Count != 0).Select(x => new
            {
                Key = x.Id,
                Value = string.Format("{0}, {1}", x.Town, x.Country),
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Key.ToString(), x.Value)).OrderBy(x => x.Value);
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllStartCountriesForFlightsAsKeyValuePairs()
        {
            return this.destinationsRepository.All().Where(x => x.DepartureFlights.Count != 0).Select(x => new
            {
                Key = x.Id,
                Value = string.Format("{0}, {1}", x.Town, x.Country),
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Key.ToString(), x.Value)).OrderBy(x => x.Value);
        }

        public async Task<DestinationViewModel> GetByIdAsync(int? id)
        {
            var destination = await this.destinationsRepository.All()
                .Where(x => x.Id == id)
                .To<DestinationViewModel>().FirstOrDefaultAsync();

            return destination;
        }

        public IndexViewModel GetDestinationsCount()
        {
            var data = new IndexViewModel()
            {
                DestinationsCount = this.destinationsRepository.All().Count(),
            };

            return data;
        }
    }
}
