namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Web.ViewModels.Hotels;

    public interface IHotelsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        Task<IEnumerable<HotelViewModel>> GetAllByDestinationIdAsync(int destinationId);

        Task<HotelViewModel> GetByIdAsync(int? id);

        Task<IEnumerable<HotelViewModel>> GetAllAsync();

        IEnumerable<HotelViewModel> GetAll();

        Task CreateAsync(HotelInputModel inputModel);

        Task DeleteAsync(int id);

        Task EditAsync(int id, HotelViewModel input);

        bool Exists(int id);
    }
}
