namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Web.ViewModels.FlightCompanies;

    public interface IFlightCompaniesService
    {
        IEnumerable<FlightCompanyViewModel> GetAll();

        Task<IEnumerable<FlightCompanyViewModel>> GetAllAsync();

        Task<FlightCompanyViewModel> GetByIdAsync(int? id);

        Task CreateAsync(FlightCompanyInputModel inputModel);

        Task DeleteAsync(int? id);
    }
}
