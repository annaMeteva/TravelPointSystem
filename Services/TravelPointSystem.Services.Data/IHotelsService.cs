namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TravelPointSystem.Web.ViewModels.Hotels;

    public interface IHotelsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        IEnumerable<HotelViewModel> GetAllByDestinationId(int destinationId);

        HotelViewModel GetById(int id);
    }
}
