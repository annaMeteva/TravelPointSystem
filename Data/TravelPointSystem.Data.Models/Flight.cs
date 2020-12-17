namespace TravelPointSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TravelPointSystem.Data.Common.Models;
    using TravelPointSystem.Data.Models.Enums;

    public class Flight : BaseDeletableModel<string>
    {
        public Flight()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Reservations = new HashSet<Reservation>();
        }

        [Required]
        public string FlightNumber { get; set; }

        [Required]
        public double PricePerPerson { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public FlightCompany Company { get; set; }

        [Required]
        public DateTime DepartureDateTime { get; set; }

        [Required]
        public TimeSpan FlightTime { get; set; }

        [Required]
        public int StartPointId { get; set; }

        public Destination StartPoint { get; set; }

        [Required]
        public string StartPointAirPort { get; set; }

        [Required]
        public int EndPointId { get; set; }

        public Destination EndPoint { get; set; }

        [Required]
        public string EndPointAirPort { get; set; }

        [Required]
        [Range(1, 900)]
        public int AvailableSeats { get; set; }

        [Required]
        public ReservationType ReservationType { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}
