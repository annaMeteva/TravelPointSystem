namespace TravelPointSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TravelPointSystem.Data.Common.Models;

    public class Flight : BaseDeletableModel<string>
    {
        public Flight()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        public string CompanyId { get; set; }

        [Required]
        public FlightCompany Company { get; set; }

        [Required]
        public DateTime DepartureDateTime { get; set; }

        public DateTime? ReturnDateTime { get; set; }

        [Required]
        public string StartPointId { get; set; }

        public Destination StartPoint { get; set; }

        [Required]
        public string EndPointId { get; set; }

        public Destination EndPoint { get; set; }

        [Required]
        public DateTime FlightTime { get; set; }

        [Required]
        [Range(1, 900)]
        public int AvailableSeats { get; set; }
    }
}
