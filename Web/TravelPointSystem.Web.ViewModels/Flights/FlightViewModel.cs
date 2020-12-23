namespace TravelPointSystem.Web.ViewModels.Flights
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Destinations;
    using TravelPointSystem.Web.ViewModels.FlightCompanies;

    public class FlightViewModel : IMapFrom<Flight>
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [Required]
        [Display(Name = "Price per person")]
        public double PricePerPerson { get; set; }

        // For EditAsync Action
        [Display(Name = "Company")]
        public int CompanyId { get; set; }

        public FlightCompanyViewModel Company { get; set; }

        [Required]
        [Display(Name = "Departure At")]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        [Display(Name = "Flight Time")]
        public TimeSpan FlightTime { get; set; }

        // For EditAsync Action
        [Display(Name = "Start Destination")]
        public int StartPointId { get; set; }

        [Display(Name = "Start Destination")]
        public DestinationViewModel StartPoint { get; set; }

        [Required]
        [Display(Name = "Start Airport")]
        public string StartPointAirPort { get; set; }

        // For EditAsync Action
        [Display(Name = "End Destination")]
        public int EndPointId { get; set; }

        [Display(Name = "End Destination")]
        public DestinationViewModel EndPoint { get; set; }

        [Required]
        [Display(Name = "End Airport")]
        public string EndPointAirPort { get; set; }

        [Required]
        [Display(Name = "Available Seats")]
        [Range(1, 900)]
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
