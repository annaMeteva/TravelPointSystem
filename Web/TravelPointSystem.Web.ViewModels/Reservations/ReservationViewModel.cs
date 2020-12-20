namespace TravelPointSystem.Web.ViewModels.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Buses;
    using TravelPointSystem.Web.ViewModels.Destinations;
    using TravelPointSystem.Web.ViewModels.Flights;
    using TravelPointSystem.Web.ViewModels.Hotels;
    using TravelPointSystem.Web.ViewModels.OrganizedTrips;
    using TravelPointSystem.Web.ViewModels.Tourists;

    public class ReservationViewModel : IMapFrom<Reservation>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public ReservationType ReservationType { get; set; }

        public IEnumerable<TouristViewModel> Tourists { get; set; }

        public double Price { get; set; }

        public double Balance { get; set; }

        public double Profit { get; set; }

        public bool IsAccepted { get; set; }

        public DestinationViewModel Destination { get; set; }

        // For Hotel Reservation Type
        public HotelViewModel Hotel { get; set; }

        // For OrganizedTrip Type
        public OrganizedTripViewModel OrganizedTrip { get; set; }

        // For Flight Type
        public FlightViewModel Flight { get; set; }

        // For Bus Type
        public BusViewModel Bus { get; set; }

        public DateTime Departure { get; set; }

        public DateTime? Return { get; set; }
    }
}
