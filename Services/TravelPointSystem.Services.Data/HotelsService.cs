namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;

    public class HotelsService : IHotelsService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelsRepository;

        public HotelsService(IDeletableEntityRepository<Hotel> hotelsRepository)
        {
            this.hotelsRepository = hotelsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.hotelsRepository.All().Select(x => new
            {
                x.Id, x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).OrderBy(x => x.Value);
        }
    }
}
