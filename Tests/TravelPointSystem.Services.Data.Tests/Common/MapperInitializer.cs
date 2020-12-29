namespace TravelPointSystem.Services.Data.Tests.Common
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Text;

    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Buses;
    using TravelPointSystem.Web.ViewModels.Flights;
    using TravelPointSystem.Web.ViewModels.Hotels;

    public class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(BusViewModel).GetTypeInfo().Assembly,
                typeof(Bus).GetTypeInfo().Assembly);

            AutoMapperConfig.RegisterMappings(
                typeof(FlightViewModel).GetTypeInfo().Assembly,
                typeof(Flight).GetTypeInfo().Assembly);

            AutoMapperConfig.RegisterMappings(
                typeof(HotelViewModel).GetTypeInfo().Assembly,
                typeof(Hotel).GetTypeInfo().Assembly);
        }
    }
}
