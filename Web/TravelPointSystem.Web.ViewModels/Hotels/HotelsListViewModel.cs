namespace TravelPointSystem.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TravelPointSystem.Data.Models.Enums;

    public class HotelsListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DestinationName { get; set; }

        public double PricePerNightPerPerson { get; set; }

        public int Stars { get; set; }

        public int AvailableRooms { get; set; }

        public FeedingType FeedingType { get; set; }

    }
}
