namespace TravelPointSystem.Web.ViewModels.FlightCompanies
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;

    public class FlightCompanyViewModel : IMapFrom<FlightCompany>
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [MaxLength(25)]
        public string Name { get; set; }

        [Display(Name = "Created On")]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Modified On")]
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Deleted On")]
        public DateTime? DeletedOn { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }
    }
}
