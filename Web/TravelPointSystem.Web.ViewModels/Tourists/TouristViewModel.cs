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

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Personal Number")]
        public ulong PersonalNumber { get; set; }

        [Required]
        [Display(Name = "Passport Number")]
        public ulong PassportNumber { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Tourist Type")]
        public TouristType TouristType { get; set; }
    }
}
