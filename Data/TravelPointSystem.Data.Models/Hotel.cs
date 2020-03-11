namespace TravelPointSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelPointSystem.Data.Common.Models;
    using TravelPointSystem.Data.Models.MappingTables;

    public class Hotel : BaseDeletableModel<string>
    {
        public Hotel()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.OrganizedTrips = new HashSet<HotelOrganizedTrip>();
        }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public string DestinationId { get; set; }

        public Destination Destination { get; set; }

        [Required]
        public double PricePerNightPerPerson { get; set; }

        [Required]
        public int Stars { get; set; }

        [Required]
        public int AvailableRooms { get; set; }

        public HashSet<HotelOrganizedTrip> OrganizedTrips { get; set; }
    }
}
