namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TravelPointSystem.Web.ViewModels.Buses;

    public interface IBusesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();

        Task<IEnumerable<BusViewModel>> GetAllByDestinationsIdAsync(int startDestinationId, int endDestinationId);

        Task<IEnumerable<BusViewModel>> GetAllAsync();

        Task<BusViewModel> GetByIdAsync(string id);

        Task CreateAsync(BusInputModel inputModel);

        Task DeleteAsync(string id);
    }
}
