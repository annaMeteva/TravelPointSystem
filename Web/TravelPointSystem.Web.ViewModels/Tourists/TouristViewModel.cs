namespace TravelPointSystem.Web.ViewModels.Tourists
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Mapping;

    public class TouristViewModel : IMapFrom<Tourist>
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public ulong PersonalNumber { get; set; }

        public ulong PassportNumber { get; set; }

        public string PhoneNumber { get; set; }

        public TouristType TouristType { get; set; }
    }
}
