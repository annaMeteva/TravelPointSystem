namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Home;

    public class DestinationsService : IDestinationsService
    {
        private readonly IDeletableEntityRepository<Destination> destinationsRepository;

        public DestinationsService(IDeletableEntityRepository<Destination> destinationsRepository)
        {
            this.destinationsRepository = destinationsRepository;
        }

        public IEnumerable<string> GetAllCountries()
        {
            var countries = this.destinationsRepository.AllAsNoTracking().OrderBy(d => d.Country).Select(d => d.Country).Distinct().ToList();

            return countries;
        }

        public IndexViewModel GetDestinationsCount()
        {
            var data = new IndexViewModel()
            {
                DestinationsCount = this.destinationsRepository.All().Count(),
            };

            return data;
        }
    }
}
