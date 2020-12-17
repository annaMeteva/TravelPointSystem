namespace TravelPointSystem.Web.ViewModels.OrganizedTrips
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Destinations;
    using TravelPointSystem.Web.ViewModels.Hotels;

    public class OrganizedTripViewModel : IMapFrom<OrganizedTrip>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public double PricePerPerson { get; set; }

        [DataType(DataType.Date)]
        public DateTime DepartureDateTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDateTime { get; set; }

        public int DestinationId { get; set; }

        public DestinationViewModel Destination { get; set; }

        public int HotelId { get; set; }

        public HotelViewModel Hotel { get; set; }

        public TransportType Transport { get; set; }

        public int AvailableSeats { get; set; }
    }
}
