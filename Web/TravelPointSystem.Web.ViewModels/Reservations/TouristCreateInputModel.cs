namespace TravelPointSystem.Web.ViewModels.Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using TravelPointSystem.Data.Models.Enums;

    public class TouristCreateInputModel
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Child or Adult")]
        public TouristType TouristType { get; set; }

        [Required]
        [Display(Name = "Personal Number")]
        public ulong PersonalNumber { get; set; }

        [Required]
        [Display(Name = "Passport Number")]
        public ulong PassportNumber { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
