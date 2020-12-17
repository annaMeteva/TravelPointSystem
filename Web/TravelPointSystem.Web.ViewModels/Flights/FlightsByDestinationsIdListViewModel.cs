namespace TravelPointSystem.Web.ViewModels.Flights
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FlightsByDestinationsIdListViewModel
    {
        public IEnumerable<FlightViewModel> Flights { get; set; }
    }
}
