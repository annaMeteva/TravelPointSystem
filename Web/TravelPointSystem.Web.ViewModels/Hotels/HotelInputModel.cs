namespace TravelPointSystem.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using TravelPointSystem.Data.Models.Enums;

    public class HotelInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Destination Town")]
        public int DestinationId { get; set; }

        [Required]
        [Display(Name = "Price per person per night")]
        public double PricePerNightPerPerson { get; set; }

        [Required]
        [Range(1, 6)]
        public int Stars { get; set; }

        [Required]
        [Display(Name = "Available Rooms")]
        public int AvailableRooms { get; set; }

        [Required]
        [Display(Name = "Feeding Type")]
        [EnumDataType(typeof(FeedingType))]
        public FeedingType FeedingType { get; set; }

        [Required]
        [Display(Name = "Reservation Type")]
        public ReservationType ReservationType { get; set; }
    }
}
