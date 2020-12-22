namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TravelPointSystem.Web.ViewModels.Destinations;
    using TravelPointSystem.Web.ViewModels.OrganizedTrips;

    public interface IOrganizedTripsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();

        Task<IEnumerable<OrganizedTripViewModel>> GetAllByDestinationIdAsync(int destinationId);

        Task<IEnumerable<OrganizedTripViewModel>> GetAllAsync();

        Task<OrganizedTripViewModel> GetByIdAsync(string id);

        Task CreateAsync(OrganizedTripInputModel inputModel);

        Task DeleteAsync(string id);
    }
}
