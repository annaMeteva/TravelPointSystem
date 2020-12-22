namespace TravelPointSystem.Web.ViewModels.Flights
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TravelPointSystem.Data.Models.Enums;

    public class FlightInputModel
    {
        [Required]
        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [Required]
        [Display(Name = "Price per person")]
        public double PricePerPerson { get; set; }

        [Required]
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        [Required]
        [Display(Name = "Departure At")]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        [Display(Name = "Flight Time")]
        public TimeSpan FlightTime { get; set; }

        [Required]
        [Display(Name = "Start Destination")]
        public int StartPointId { get; set; }

        [Required]
        [Display(Name = "Start Airport")]
        public string StartPointAirPort { get; set; }

        [Required]
        [Display(Name = "End Destination")]
        public int EndPointId { get; set; }

        [Required]
        [Display(Name = "End Airport")]
        public string EndPointAirPort { get; set; }

        [Required]
        [Display(Name = "Available Seats")]
        [Range(1, 900)]
        public int AvailableSeats { get; set; }

        [Required]
        [Display(Name = "Reservation Type")]
        public ReservationType ReservationType { get; set; }
    }
}
