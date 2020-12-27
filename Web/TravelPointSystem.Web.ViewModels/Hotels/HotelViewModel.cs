namespace TravelPointSystem.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Destinations;

    public class HotelViewModel : IMapFrom<Hotel>
    {
        public int Id { get; set; }

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

        // For EditAsync Action
        [Display(Name = "Destination")]
        public int DestinationId { get; set; }

        public DestinationViewModel Destination { get; set; }

        [Required]
        [Display(Name = "Price per person")]
        public double PricePerNightPerPerson { get; set; }

        public double PricePerChild => Math.Round(this.PricePerNightPerPerson / 2, 2);

        [Required]
        [Range(1, 6)]
        public int Stars { get; set; }

        [Required]
        [Display(Name = "Available Rooms")]
        public int AvailableRooms { get; set; }

        [Display(Name = "Feeding Type")]
        public FeedingType FeedingType { get; set; }

        [Display(Name = "Reservation Type")]
        public ReservationType ReservationType { get; set; }

        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Deleted On")]
        public DateTime? DeletedOn { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }

        public int NumberOfTourists { get; set; }
    }
}
