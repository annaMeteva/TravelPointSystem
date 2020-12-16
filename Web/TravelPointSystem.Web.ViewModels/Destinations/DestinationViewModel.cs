namespace TravelPointSystem.Web.ViewModels.Destinations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;

    public class DestinationViewModel : IMapFrom<Destination>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }
    }
}
