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

        [Display(Name = "Image Link")]
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DestinationViewModel Destination { get; set; }

        [Display(Name = "Price")]
        public double PricePerNightPerPerson { get; set; }

        public int Stars { get; set; }

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
    }
}
