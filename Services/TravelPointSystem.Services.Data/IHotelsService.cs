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

        IEnumerable<HotelViewModel> GetAllByDestinationId(int destinationId);

        Task<HotelViewModel> GetByIdAsync(int? id);

        Task<IEnumerable<HotelViewModel>> GetAllAsync();

        Task CreateAsync(HotelInputModel inputModel);
    }
}
