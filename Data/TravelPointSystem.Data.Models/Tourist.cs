namespace TravelPointSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TravelPointSystem.Data.Common.Models;
    using TravelPointSystem.Data.Models.MappingTables;

    public class Tourist : BaseDeletableModel<string>
    {
        public Tourist()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
            this.IsDeleted = false;
            this.Reservations = new HashSet<ReservationTourist>();
        }

        [Required]
        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required]
        public ulong PersonalNumber { get; set; }

        [Required]
        public ulong PassportNumber { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<ReservationTourist> Reservations { get; set; }
    }
}
