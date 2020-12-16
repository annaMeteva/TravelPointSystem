namespace TravelPointSystem.Web.ViewModels.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class OrganizedTripCreateInputModel
    {
        [Required]
        [Display(Name = "Organized Trip name")]
        public string OrganizedTripName { get; set; }

        public IEnumerable<KeyValuePair<string, string>> OrganizedTripsItems { get; set; }
    }
}
