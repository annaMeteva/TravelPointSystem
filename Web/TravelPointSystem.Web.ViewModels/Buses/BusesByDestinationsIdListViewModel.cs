namespace TravelPointSystem.Web.ViewModels.Buses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BusesByDestinationsIdListViewModel
    {
        public int NumberOfTourists { get; set; }

        public IEnumerable<BusViewModel> Buses { get; set; }
    }
}
