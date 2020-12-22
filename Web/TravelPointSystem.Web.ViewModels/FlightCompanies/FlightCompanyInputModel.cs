namespace TravelPointSystem.Web.ViewModels.FlightCompanies
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class FlightCompanyInputModel
    {
        [Required]
        [MaxLength(25)]
        [Display(Name = "Company Name")]
        public string Name { get; set; }
    }
}
