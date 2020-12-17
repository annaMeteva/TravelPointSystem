namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Buses;

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

        public IEnumerable<BusViewModel> GetAllByDestinationsId(int startDestinationId, int endDestinationId)
        {
            return this.busesRepository.AllAsNoTracking()
                .Where(b => b.StartPointId == startDestinationId && b.EndPointId == endDestinationId)
                .OrderBy(f => f.BusNumber)
                .To<BusViewModel>();
        }
    }
}
