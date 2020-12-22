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

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; }

        public string Description { get; set; }

        [Display(Name = "Price")]
        public double PricePerPerson { get; set; }

        [Display(Name = "Departure At")]
        public DateTime DepartureDateTime { get; set; }

        [Display(Name = "Return At")]
        public DateTime ReturnDateTime { get; set; }

        public DestinationViewModel Destination { get; set; }

        public HotelViewModel Hotel { get; set; }

        public TransportType Transport { get; set; }

        [Display(Name = "Available Seats")]
        public int AvailableSeats { get; set; }

        [Display(Name = "Reservation Type")]
        public ReservationType ReservationType { get; set; }

        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Deleted On")]
        public DateTime? DeletedOn { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }
    }
}
