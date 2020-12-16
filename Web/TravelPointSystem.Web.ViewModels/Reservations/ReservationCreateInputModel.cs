namespace TravelPointSystem.Web.ViewModels.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using TravelPointSystem.Data.Models.Enums;

    public class ReservationCreateInputModel
    {
        [Required]
        [Display(Name = "Select reservation type")]
        public ReservationType ReservationType { get; set; }

        [Required]
        [Range(1, 4)]
        [Display(Name = "Number of tourists (1 or 4)")]
        public int NumberOfTourists { get; set; }
    }
}
