namespace TravelPointSystem.Web.ViewModels.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
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
    using TravelPointSystem.Web.ViewModels.Users;

    public class ReservationViewModel : IMapFrom<Reservation>
    {
        public string Id { get; set; }

        [Display(Name = "Reservation Type")]
        public ReservationType ReservationType { get; set; }

        public IEnumerable<TouristViewModel> Tourists { get; set; }

        public double Price { get; set; }

        public double Balance { get; set; }

        public double Profit { get; set; }

        [Display(Name = "Is Accepted")]
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

        [Display(Name = "Departure At")]
        public DateTime Departure { get; set; }

        [Display(Name = "Return At")]
        public DateTime? Return { get; set; }

        public UserViewModel Creator { get; set; }

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
