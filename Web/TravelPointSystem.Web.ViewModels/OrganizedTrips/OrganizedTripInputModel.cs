namespace TravelPointSystem.Web.ViewModels.OrganizedTrips
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TravelPointSystem.Data.Models.Enums;

    public class OrganizedTripInputModel
    {
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

        [Required]
        [Display(Name = "Destination")]
        public int DestinationId { get; set; }

        [Required]
        [Display(Name = "Hotel Name")]
        public int HotelId { get; set; }

        [Required]
        [Display(Name = "Available Seats")]
        public int AvailableSeats { get; set; }

        [Required]
        public TransportType Transport { get; set; }

        [Required]
        [Display(Name = "Reservation Type")]
        public ReservationType ReservationType { get; set; }
    }
}
