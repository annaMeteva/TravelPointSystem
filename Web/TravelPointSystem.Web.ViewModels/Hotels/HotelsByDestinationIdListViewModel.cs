namespace TravelPointSystem.Web.ViewModels.Hotels
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HotelsByDestinationIdListViewModel
    {
        public int NumberOfTourists { get; set; }

        public IEnumerable<HotelViewModel> Hotels { get; set; }
    }
}
