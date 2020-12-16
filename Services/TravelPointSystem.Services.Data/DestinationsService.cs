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

        public IEnumerable<KeyValuePair<string, string>> GetAllCountriesAsKeyValuePairs()
        {
            return this.destinationsRepository.All().Select(x => new
            {
                Key = x.Id,
                Value = string.Format("{0}, {1}", x.Country, x.Town),
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Key.ToString(), x.Value)).OrderBy(x => x.Value);
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
