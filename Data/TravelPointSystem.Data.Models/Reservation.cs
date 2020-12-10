namespace TravelPointSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelPointSystem.Data.Common.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Data.Models.MappingTables;

    public class Reservation : BaseDeletableModel<string>
    {
        public Reservation()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Tourists = new HashSet<ReservationTourist>();
        }

        public string Name { get; set; }

        [Required]
        public ReservationType Type { get; set; }

        public int DepartureDaysLeft { get; set; }

        [Required]
        [Range(1, 2)]
        public int NumberOfToursts { get; set; }

        public ICollection<ReservationTourist> Tourists { get; set; }

        public double Price { get; set; }

        public double Balance { get; set; }

        public double Profit { get; set; }

        public bool IsPaid { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }
    }
}
