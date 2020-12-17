namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TravelPointSystem.Web.ViewModels.Destinations;
    using TravelPointSystem.Web.ViewModels.OrganizedTrips;

    public interface IOrganizedTripsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();

        IEnumerable<OrganizedTripViewModel> GetAllByDestinationId(int destinationId);

        OrganizedTripViewModel GetById(string id);
    }
}
