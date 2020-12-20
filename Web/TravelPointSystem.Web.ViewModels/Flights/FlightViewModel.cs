namespace TravelPointSystem.Web.ViewModels.Flights
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Destinations;

    public class FlightViewModel : IMapFrom<Flight>
    {
        public string Id { get; set; }

        public string FlightNumber { get; set; }

        public double PricePerPerson { get; set; }

        public FlightCompanyViewModel Company { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public TimeSpan FlightTime { get; set; }

        public DestinationViewModel StartPoint { get; set; }

        public string StartPointAirPort { get; set; }

        public DestinationViewModel EndPoint { get; set; }

        public string EndPointAirPort { get; set; }

        public int AvailableSeats { get; set; }

        public ReservationType ReservationType { get; set; }
    }
}
