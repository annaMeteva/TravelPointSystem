namespace TravelPointSystem.Web.ViewModels.Buses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Destinations;

    public class BusViewModel : IMapFrom<Bus>
    {
        public string Id { get; set; }

        public string BusNumber { get; set; }

        public double PricePerPerson { get; set; }

        public DateTime DepartureDateTime { get; set; }

        public TimeSpan TravellingTime { get; set; }

        public int AvailableSeats { get; set; }

        public DestinationViewModel StartPoint { get; set; }

        public string StartPointStation { get; set; }

        public DestinationViewModel EndPoint { get; set; }

        public string EndPointStation { get; set; }

        public ReservationType ReservationType { get; set; }

    }
}
