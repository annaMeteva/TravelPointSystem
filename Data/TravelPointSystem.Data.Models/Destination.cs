namespace TravelPointSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelPointSystem.Data.Common.Models;
    using TravelPointSystem.Data.Models.MappingTables;

    public class Destination : BaseDeletableModel<int>
    {
        public Destination()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Hotels = new HashSet<Hotel>();
            this.DepartureFlights = new HashSet<Flight>();
            this.DepartingFlights = new HashSet<Flight>();
            this.DepartureBuses = new HashSet<Bus>();
            this.DepartingBuses = new HashSet<Bus>();
            this.OrganizedTrips = new HashSet<DestinationOrganizedTrip>();
        }

        [Required]
        public string Continent { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Flag { get; set; }

        [Required]
        public int Town { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get; set; }

        public HashSet<Hotel> Hotels { get; set; }

        public HashSet<Flight> DepartureFlights { get; set; }

        public HashSet<Flight> DepartingFlights { get; set; }

        public HashSet<Bus> DepartureBuses { get; set; }

        public HashSet<Bus> DepartingBuses { get; set; }

        public HashSet<DestinationOrganizedTrip> OrganizedTrips { get; set; }
    }
}
