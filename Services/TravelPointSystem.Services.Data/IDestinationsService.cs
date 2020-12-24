namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Web.ViewModels.Destinations;
    using TravelPointSystem.Web.ViewModels.Home;

    public interface IDestinationsService
    {
        int GetDestinationsCount();

        IEnumerable<KeyValuePair<string, string>> GetAllCountriesForTripsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllCountriesForHotelsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllStartCountriesForFlightsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllEndCountriesForFlightsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllStartCountriesForBusesAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllEndCountriesForBusesAsKeyValuePairs();

        IEnumerable<DestinationViewModel> GetAll();

        Task<IEnumerable<DestinationViewModel>> GetAllAsync();

        Task<DestinationViewModel> GetByIdAsync(int? id);

        Task CreateAsync(DestinationInputModel inputModel);

        Task DeleteAsync(int? id);

        Task EditAsync(int id, DestinationViewModel input);

        bool Exists(int id);
    }
}
