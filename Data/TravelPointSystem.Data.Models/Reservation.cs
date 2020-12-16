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


        [Required]
        public ReservationType Type { get; set; }

        [Required]
        [Range(1, 4)]
        public int NumberOfToursts { get; set; }

        public double Price { get; set; }

        public double Balance { get; set; }

        public double Profit { get; set; }

        public bool IsPaid { get; set; }

        public bool IsAccepted { get; set; }

        public int DepartureDaysLeft { get; set; }

        [Required]
        public string CreatorId { get; set; }

        public ApplicationUser Creator { get; set; }

        public ICollection<ReservationTourist> Tourists { get; set; }

        // For Hotel Reservation Type
        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        // For OrganizedTrip Type
        public string OrganizedTripId { get; set; }

        public OrganizedTrip OrganizedTrip { get; set; }

        // For Flight Type
        public string FlightId { get; set; }

        public Flight Flight { get; set; }

        // For Bus Type
        public string BusId { get; set; }

        public Bus Bus { get; set; }
    }
}
