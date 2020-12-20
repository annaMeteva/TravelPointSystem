namespace TravelPointSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelPointSystem.Data.Common.Models;
    using TravelPointSystem.Data.Models.Enums;

    public class OrganizedTrip : BaseDeletableModel<string>
    {
        public OrganizedTrip()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double PricePerPerson { get; set; }

        [Required]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        public DateTime ReturnDateTime { get; set; }

        [Required]
        public int DestinationId { get; set; }

        public Destination Destination { get; set; }

        [Required]
        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public TransportType Transport { get; set; }

        [Required]
        public int AvailableSeats { get; set; }

        [Required]
        public ReservationType ReservationType { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
