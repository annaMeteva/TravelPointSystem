namespace TravelPointSystem.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class HotelsByDestinationIdInputModel
    {
        [Required]
        [Display(Name = "Please choose destination")]
        public string DestinationId{ get; set; }

        [Required]
        [Range(1, 4)]
        [Display(Name = "Number of tourists")]
        public int NumberOfTourists { get; set; }

        public IEnumerable<KeyValuePair<string, string>> DestinationItems { get; set; }
    }
}
