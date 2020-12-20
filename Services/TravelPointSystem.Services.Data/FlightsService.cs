namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            return this.flightsRepository.All().Select(x => new
            {
                x.Id,
                x.FlightNumber,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.FlightNumber)).OrderBy(x => x.Value);
        }

        public IEnumerable<FlightViewModel> GetAllByDestinationsId(int startDestinationId, int endDestinationId)
        {
            return this.flightsRepository.All()
                .Where(f => f.StartPointId == startDestinationId && f.EndPointId == endDestinationId)
                .OrderBy(f => f.FlightNumber)
                .To<FlightViewModel>();
        }
    }
}
