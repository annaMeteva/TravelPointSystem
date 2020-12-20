namespace TravelPointSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelPointSystem.Data.Common.Models;

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
            this.OrganizedTrips = new HashSet<OrganizedTrip>();
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        public string Continent { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Town { get; set; }

        public ICollection<Hotel> Hotels { get; set; }

        public ICollection<Flight> DepartureFlights { get; set; }

        public ICollection<Flight> DepartingFlights { get; set; }

        public ICollection<Bus> DepartureBuses { get; set; }

        public ICollection<Bus> DepartingBuses { get; set; }

        public ICollection<OrganizedTrip> OrganizedTrips { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
