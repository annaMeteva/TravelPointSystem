namespace TravelPointSystem.Web.ViewModels.Flights
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;

    public class FlightCompanyViewModel : IMapFrom<FlightCompany>
    {
        public string Name { get; set; }
    }
}
