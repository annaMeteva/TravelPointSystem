namespace TravelPointSystem.Web.ViewModels.Destinations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class DestinationInputModel
    {
        [Required]
        [MaxLength(50)]
        public string Continent { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        public string Town { get; set; }
    }
}
