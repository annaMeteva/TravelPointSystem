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

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Price per person")]
        public double PricePerPerson { get; set; }

        [Required]
        [Display(Name = "Departure At")]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        [Display(Name = "Return At")]
        public DateTime ReturnDateTime { get; set; }

        // For EditAsync Action
        [Display(Name = "Destination")]
        public int DestinationId { get; set; }

        public DestinationViewModel Destination { get; set; }

        // For EditAsync Action
        [Display(Name = "Hotel")]
        public int HotelId { get; set; }

        public HotelViewModel Hotel { get; set; }

        [Required]
        public TransportType Transport { get; set; }

        [Required]
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

        public int NumberOfTourists { get; set; }
    }
}
