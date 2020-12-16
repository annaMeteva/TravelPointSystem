namespace TravelPointSystem.Web.ViewModels.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class FlightCreateInputModel
    {
        [Required]
        [Display(Name = "Flight number")]
        public string FlightNumber { get; set; }

        public IEnumerable<KeyValuePair<string, string>> FlightsItems { get; set; }
    }
}
