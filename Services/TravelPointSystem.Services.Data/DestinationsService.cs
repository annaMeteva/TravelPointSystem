namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Home;

    public class DestinationsService : IDestinationsService
    {
        private readonly IDeletableEntityRepository<Destination> destinationsRepository;

        public DestinationsService(IDeletableEntityRepository<Destination> destinationsRepository)
        {
            this.destinationsRepository = destinationsRepository;
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
