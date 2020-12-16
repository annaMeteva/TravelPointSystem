namespace TravelPointSystem.Web.ViewModels.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class BusCreateInputModel
    {
        [Required]
        [Display(Name = "Bus number")]
        public string BusNumber { get; set; }

        public IEnumerable<TouristCreateInputModel> Tourists { get; set; }

        public IEnumerable<KeyValuePair<string, string>> BusesItems { get; set; }
    }
}
