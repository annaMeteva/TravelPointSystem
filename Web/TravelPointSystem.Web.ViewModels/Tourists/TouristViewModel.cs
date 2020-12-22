namespace TravelPointSystem.Web.ViewModels.Tourists
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Mapping;

    public class TouristViewModel : IMapFrom<Tourist>
    {
        public string Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Personal Number")]
        public ulong PersonalNumber { get; set; }

        [Display(Name = "Passport Number")]
        public ulong PassportNumber { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tourist Type")]
        public TouristType TouristType { get; set; }
    }
}
