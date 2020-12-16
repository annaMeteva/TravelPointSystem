namespace TravelPointSystem.Web.ViewModels.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class HotelCreateInputModel
    {
        [Required]
        [Display(Name = "Hotel name")]
        public string HotelId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Check In")]
        public DateTime CheckIn { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Check Out")]
        public DateTime CheckOut { get; set; }

        public IEnumerable<KeyValuePair<string, string>> HotelsItems { get; set; }
    }
}
