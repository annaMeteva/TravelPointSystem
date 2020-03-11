namespace TravelPointSystem.Data.Models.MappingTables
{
    public class DestinationReservation
    {
        public int DestinationId { get; set; }

        public Destination Destination { get; set; }

        public string ReservationId { get; set; }

        public Reservation Reservation { get; set; }
    }
}
