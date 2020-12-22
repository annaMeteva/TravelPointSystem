namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.FlightCompanies;

    public class FlightCompaniesService : IFlightCompaniesService
    {
        private readonly IDeletableEntityRepository<FlightCompany> flightCompaniesRepository;
        private readonly IDeletableEntityRepository<Flight> flightsRepository;

        public FlightCompaniesService(IDeletableEntityRepository<FlightCompany> flightCompaniesRepository, IDeletableEntityRepository<Flight> flightsRepository)
        {
            this.flightCompaniesRepository = flightCompaniesRepository;
            this.flightsRepository = flightsRepository;
        }

        public async Task CreateAsync(FlightCompanyInputModel inputModel)
        {
            var company = new FlightCompany
            {
                Name = inputModel.Name,
            };

            await this.flightCompaniesRepository.AddAsync(company);
            await this.flightCompaniesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            var company = await this.flightCompaniesRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            var flights = await this.flightsRepository.All()
                .Where(x => x.CompanyId == id).ToListAsync();

            foreach (var flight in flights)
            {
                this.flightsRepository.Delete(flight);
            }

            this.flightCompaniesRepository.Delete(company);

            await this.flightsRepository.SaveChangesAsync();
            await this.flightCompaniesRepository.SaveChangesAsync();
        }

        public IEnumerable<FlightCompanyViewModel> GetAll()
        {
            return this.flightCompaniesRepository.All().OrderBy(x => x.Name).To<FlightCompanyViewModel>();
        }

        public async Task<IEnumerable<FlightCompanyViewModel>> GetAllAsync()
        {
            var companies = await this.flightCompaniesRepository.All().OrderBy(x => x.Name).To<FlightCompanyViewModel>().ToListAsync();

            return companies;
        }

        public async Task<FlightCompanyViewModel> GetByIdAsync(int? id)
        {
            var company = await this.flightCompaniesRepository.All()
                .Where(x => x.Id == id)
                .To<FlightCompanyViewModel>().FirstOrDefaultAsync();

            return company;
        }
    }
}
