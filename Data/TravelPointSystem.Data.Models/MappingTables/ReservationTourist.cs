namespace TravelPointSystem.Data.Models.MappingTables
{
    public class ReservationTourist
    {
        public string ReservationId { get; set; }

        public Reservation Reservation { get; set; }

        public string TouristId { get; set; }

        public Tourist Tourist { get; set; }
    }
}
