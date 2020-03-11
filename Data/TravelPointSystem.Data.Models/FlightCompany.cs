namespace TravelPointSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TravelPointSystem.Data.Common.Models;

    public class FlightCompany : BaseDeletableModel<int>
    {
        public FlightCompany()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Flights = new HashSet<Flight>();
        }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [MinLength(5)]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public string Logo { get; set; }

        public HashSet<Flight> Flights { get; set; }
    }
}
