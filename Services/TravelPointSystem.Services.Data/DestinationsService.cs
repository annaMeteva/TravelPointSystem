namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Web.ViewModels.Home;

    public class DestinationsService : IDestinationsService
    {
        private readonly IDeletableEntityRepository<Destination> destinationsRepository;

        public DestinationsService(IDeletableEntityRepository<Destination> destinationsRepository)
        {
            this.destinationsRepository = destinationsRepository;
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
