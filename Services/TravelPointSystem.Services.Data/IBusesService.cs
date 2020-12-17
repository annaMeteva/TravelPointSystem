namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TravelPointSystem.Web.ViewModels.Buses;

    public interface IBusesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();

        IEnumerable<BusViewModel> GetAllByDestinationsId(int startDestinationId, int endDestinationId);
    }
}
