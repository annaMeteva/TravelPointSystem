namespace TravelPointSystem.Web.ViewModels.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TravelPointSystem.Data.Models.Enums;

    public class ReservationCreateInputModel
    {
        public ReservationType ReservationType { get; set; }

        public string ProductId { get; set; }

        public int NumberOfTourists { get; set; }

        // For Hotel Reservation
        [DataType(DataType.Date)]
        [Display(Name = "Check In")]
        public DateTime CheckIn { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Check Out")]
        public DateTime CheckOut { get; set; }

        public IList<TouristCreateInputModel> Tourists { get; set; }
    }
}
