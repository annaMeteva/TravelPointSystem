namespace TravelPointSystem.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Destinations;

    public class HotelViewModel : IMapFrom<Hotel>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DestinationViewModel Destination { get; set; }

        public double PricePerNightPerPerson { get; set; }

        public int Stars { get; set; }

        public int AvailableRooms { get; set; }

        public FeedingType FeedingType { get; set; }
    }
}
