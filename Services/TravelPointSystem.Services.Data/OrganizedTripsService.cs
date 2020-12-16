namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Destinations;
    using TravelPointSystem.Web.ViewModels.OrganizedTrips;

    public class OrganizedTripsService : IOrganizedTripsService
    {
        private readonly IDeletableEntityRepository<OrganizedTrip> organizedTripsRepository;

        public OrganizedTripsService(IDeletableEntityRepository<OrganizedTrip> organizedTripsRepository)
        {
            this.organizedTripsRepository = organizedTripsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            return this.organizedTripsRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).OrderBy(x => x.Value);
        }

        public IEnumerable<OrganizedTripViewModel> GetAllByDestinationId(int destinationId)
        {
            return this.organizedTripsRepository.AllAsNoTracking()
                .Where(h => h.DestinationId == destinationId)
                .OrderBy(h => h.Name).To<OrganizedTripViewModel>();
        }
    }
}
