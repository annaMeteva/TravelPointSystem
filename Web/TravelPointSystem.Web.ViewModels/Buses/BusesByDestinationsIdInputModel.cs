namespace TravelPointSystem.Web.ViewModels.Buses
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class BusesByDestinationsIdInputModel
    {
        [Required]
        [Display(Name = "Please choose Start Point")]
        public string StartPointId { get; set; }

        [Required]
        [Display(Name = "Please choose End Point")]
        public string EndPointId { get; set; }

        public IEnumerable<KeyValuePair<string, string>> StartDestinationItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> EndDestinationItems { get; set; }
    }
}
