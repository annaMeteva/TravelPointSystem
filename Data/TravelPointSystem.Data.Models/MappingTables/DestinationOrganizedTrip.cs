namespace TravelPointSystem.Data.Models.MappingTables
{
    public class DestinationOrganizedTrip
    {
        public int Id { get; set; }

        public int DestinationId { get; set; }

        public Destination Destination { get; set; }

        public string OrganizedTripId { get; set; }

        public OrganizedTrip OrganizedTrip { get; set; }
    }
}
