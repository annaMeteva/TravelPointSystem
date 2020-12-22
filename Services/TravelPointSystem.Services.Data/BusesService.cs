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
    using TravelPointSystem.Web.ViewModels.Buses;

    public class BusesService : IBusesService
    {
        private readonly IDeletableEntityRepository<Bus> busesRepository;

        public BusesService(IDeletableEntityRepository<Bus> busesRepository)
        {
            this.busesRepository = busesRepository;
        }

        public async Task CreateAsync(BusInputModel inputModel)
        {
            var bus = new Bus
            {
                BusNumber = inputModel.BusNumber,
                PricePerPerson = inputModel.PricePerPerson,
                DepartureDateTime = inputModel.DepartureDateTime,
                TravellingTime = inputModel.TravellingTime,
                AvailableSeats = inputModel.AvailableSeats,
                StartPointId = inputModel.StartPointId,
                StartPointStation = inputModel.StartPointStation,
                EndPointId = inputModel.EndPointId,
                EndPointStation = inputModel.EndPointStation,
                ReservationType = inputModel.ReservationType,
            };

            await this.busesRepository.AddAsync(bus);
            await this.busesRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var bus = await this.busesRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            this.busesRepository.Delete(bus);

            await this.busesRepository.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            return this.busesRepository.All().Select(x => new
            {
                x.Id,
                x.BusNumber,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id, x.BusNumber)).OrderBy(x => x.Value);
        }

        public async Task<IEnumerable<BusViewModel>> GetAllAsync()
        {
            var buses = await this.busesRepository.All().OrderBy(x => x.BusNumber).To<BusViewModel>().ToListAsync();

            return buses;
        }

        public async Task<IEnumerable<BusViewModel>> GetAllByDestinationsIdAsync(int startDestinationId, int endDestinationId)
        {
            return await this.busesRepository.All()
                .Where(b => b.StartPointId == startDestinationId && b.EndPointId == endDestinationId)
                .OrderBy(f => f.BusNumber)
                .To<BusViewModel>()
                .ToListAsync();
        }

        public async Task<BusViewModel> GetByIdAsync(string id)
        {
            var bus = await this.busesRepository.All()
                .Where(x => x.Id == id)
                .To<BusViewModel>().FirstOrDefaultAsync();

            return bus;
        }
    }
}
