namespace TravelPointSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TravelPointSystem.Data.Common.Models;

    public class Bus : BaseDeletableModel<string>
    {
        public Bus()
        {
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
        }

        [Required]
        public DateTime DepartureDateTime { get; set; }

        public DateTime? ReturnDateTime { get; set; }

        [Required]
        [Range(1, 60)]
        public int AvailableSeats { get; set; }

        [Required]
        public int StartPointId { get; set; }

        public Destination StartPoint { get; set; }

        [Required]
        public int EndPointId { get; set; }

        public Destination EndPoint { get; set; }
    }
}
