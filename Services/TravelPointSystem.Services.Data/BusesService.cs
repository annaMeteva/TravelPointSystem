namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;

    public class BusesService : IBusesService
    {
        private readonly IDeletableEntityRepository<Bus> busesRepository;

        public BusesService(IDeletableEntityRepository<Bus> busesRepository)
        {
            this.busesRepository = busesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            return this.busesRepository.All().Select(x => new
            {
                x.Id,
                x.BusNumber,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.BusNumber)).OrderBy(x => x.Value);
        }
    }
}
