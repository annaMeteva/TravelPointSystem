namespace TravelPointSystem.Data.Models.MappingTables
{
    public class HotelOrganizedTrip
    {
        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public string OrganizedTripId { get; set; }

        public OrganizedTrip OrganizedTrip { get; set; }
    }
}
