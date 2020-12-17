namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TravelPointSystem.Web.ViewModels.Home;

    public interface IDestinationsService
    {
        IndexViewModel GetDestinationsCount();

        IEnumerable<KeyValuePair<string, string>> GetAllCountriesForTripsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllCountriesForHotelsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllStartCountriesForFlightsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllEndCountriesForFlightsAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllStartCountriesForBusesAsKeyValuePairs();

        IEnumerable<KeyValuePair<string, string>> GetAllEndCountriesForBusesAsKeyValuePairs();
    }
}
