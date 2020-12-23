namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TravelPointSystem.Web.ViewModels.Flights;

    public interface IFlightsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();

        Task<IEnumerable<FlightViewModel>> GetAllByDestinationsIdAsync(int startDestinationId, int endDestinationId);

        Task<IEnumerable<FlightViewModel>> GetAllAsync();

        Task<FlightViewModel> GetByIdAsync(string id);

        Task CreateAsync(FlightInputModel inputModel);

        Task DeleteAsync(string id);

        Task EditAsync(string id, FlightViewModel input);

        bool Exists(string id);
    }
}
