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

        [Display(Name = "Flight Number")]
        public string FlightNumber { get; set; }

        [Display(Name = "Price")]
        public double PricePerPerson { get; set; }

        public FlightCompanyViewModel Company { get; set; }

        [Display(Name = "Departure At")]
        public DateTime DepartureDateTime { get; set; }

        [Display(Name = "Flight Time")]
        public TimeSpan FlightTime { get; set; }

        [Display(Name = "Start Destination")]
        public DestinationViewModel StartPoint { get; set; }

        [Display(Name = "Start Airport")]
        public string StartPointAirPort { get; set; }

        [Display(Name = "End Destination")]
        public DestinationViewModel EndPoint { get; set; }

        [Display(Name = "End Airport")]
        public string EndPointAirPort { get; set; }

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
