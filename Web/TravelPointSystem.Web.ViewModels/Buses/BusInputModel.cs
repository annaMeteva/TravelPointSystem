namespace TravelPointSystem.Web.ViewModels.Buses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Web.ViewModels.Destinations;

    public class BusInputModel
    {
        [Required]
        [Display(Name = "Bus Number")]
        public string BusNumber { get; set; }

        [Required]
        [Display(Name = "Price per person")]
        public double PricePerPerson { get; set; }

        [Required]
        [Display(Name = "Departune At")]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        [Display(Name = "Travelling Time")]
        public TimeSpan TravellingTime { get; set; }

        [Required]
        [Display(Name = "Available Seats")]
        [Range(1, 60)]
        public int AvailableSeats { get; set; }

        [Required]
        [Display(Name = "Start Destination")]
        public int StartPointId { get; set; }

        [Required]
        [Display(Name = "Start Station Name")]
        public string StartPointStation { get; set; }

        [Required]
        [Display(Name = "End Destination")]
        public int EndPointId { get; set; }

        [Required]
        [Display(Name = "End Station Name")]
        public string EndPointStation { get; set; }

        [Required]
        [Display(Name = "Reservation Type")]
        public ReservationType ReservationType { get; set; }

    }
}
