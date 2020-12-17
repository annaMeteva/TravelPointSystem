namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TravelPointSystem.Web.ViewModels.Flights;

    public interface IFlightsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();

        IEnumerable<FlightViewModel> GetAllByDestinationsId(int startDestinationId, int endDestinationId);
    }
}
