namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;

    public class FlightsService : IFlightsService
    {
        private readonly IDeletableEntityRepository<Flight> flightsRepository;

        public FlightsService(IDeletableEntityRepository<Flight> flightsRepository)
        {
            this.flightsRepository = flightsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            return this.flightsRepository.All().Select(x => new
            {
                x.Id,
                x.FlightNumber,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.FlightNumber)).OrderBy(x => x.Value);
        }
    }
}
