namespace TravelPointSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelPointSystem.Data.Common.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Data.Models.MappingTables;

    public class OrganizedTrip : BaseDeletableModel<string>
    {
        public OrganizedTrip()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Destinations = new HashSet<DestinationOrganizedTrip>();
            this.Hotels = new HashSet<HotelOrganizedTrip>();
        }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public double PricePerPerson { get; set; }

        [Required]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        public DateTime ReturnDateTime { get; set; }

        public int Days { get; set; }

        [Required]
        [Range(1, 3)]
        public int DestinationsNumber { get; set; }

        public HashSet<DestinationOrganizedTrip> Destinations { get; set; }

        public HashSet<HotelOrganizedTrip> Hotels { get; set; }

        public TransportType Transport { get; set; }

        public int AvailableSeats { get; set; }
    }
}
