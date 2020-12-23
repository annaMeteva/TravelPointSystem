namespace TravelPointSystem.Web.ViewModels.Buses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Destinations;

    public class BusViewModel : IMapFrom<Bus>
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Bus Number")]
        public string BusNumber { get; set; }

        [Required]
        [Display(Name = "Price per person")]
        public double PricePerPerson { get; set; }

        [Required]
        [Display(Name = "Departure At")]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        [Display(Name = "Travelling Time")]
        public TimeSpan TravellingTime { get; set; }

        [Required]
        [Display(Name = "Available Seats")]
        [Range(1, 60)]
        public int AvailableSeats { get; set; }

        // For EditAsync Action
        [Display(Name = "Start Destination")]
        public int StartPointId { get; set; }

        [Display(Name = "Start Destination")]
        public DestinationViewModel StartPoint { get; set; }

        [Required]
        [Display(Name = "Start Station")]
        public string StartPointStation { get; set; }

        // For EditAsync Action
        [Display(Name = "End Destination")]
        public int EndPointId { get; set; }

        [Display(Name = "End Destination")]
        public DestinationViewModel EndPoint { get; set; }

        [Required]
        [Display(Name = "End Station")]
        public string EndPointStation { get; set; }

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
