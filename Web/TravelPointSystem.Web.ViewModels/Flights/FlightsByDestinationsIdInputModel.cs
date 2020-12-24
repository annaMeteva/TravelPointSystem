namespace TravelPointSystem.Web.ViewModels.Flights
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class FlightsByDestinationsIdInputModel
    {
        [Required]
        [Display(Name = "Please choose Start Point")]
        public string StartPointId { get; set; }

        [Required]
        [Display(Name = "Please choose End Point")]
        public string EndPointId { get; set; }

        [Required]
        [Range(1, 4)]
        [Display(Name = "Number of tourists")]
        public int NumberOfTourists { get; set; }

        public IEnumerable<KeyValuePair<string, string>> StartDestinationItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> EndDestinationItems { get; set; }
    }
}
