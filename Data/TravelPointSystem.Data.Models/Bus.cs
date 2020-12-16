namespace TravelPointSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelPointSystem.Data.Common.Models;

    public class Bus : BaseDeletableModel<string>
    {
        public Bus()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        public string BusNumber { get; set; }

        [Required]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        public TimeSpan TravellingTime { get; set; }

        [Required]
        [Range(1, 60)]
        public int AvailableSeats { get; set; }

        [Required]
        public int StartPointId { get; set; }

        public Destination StartPoint { get; set; }

        [Required]
        public int EndPointId { get; set; }

        public Destination EndPoint { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
