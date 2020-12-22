namespace TravelPointSystem.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Destinations;
    using TravelPointSystem.Web.ViewModels.OrganizedTrips;

    public class OrganizedTripsService : IOrganizedTripsService
    {
        private readonly IDeletableEntityRepository<OrganizedTrip> organizedTripsRepository;

        public OrganizedTripsService(IDeletableEntityRepository<OrganizedTrip> organizedTripsRepository)
        {
            this.organizedTripsRepository = organizedTripsRepository;
        }

        public async Task CreateAsync(OrganizedTripInputModel inputModel)
        {
            var trip = new OrganizedTrip
            {
                Name = inputModel.Name,
                ImageUrl = inputModel.ImageUrl,
                Description = inputModel.Description,
                PricePerPerson = inputModel.PricePerPerson,
                DepartureDateTime = inputModel.DepartureDateTime,
                ReturnDateTime = inputModel.ReturnDateTime,
                DestinationId = inputModel.DestinationId,
                HotelId = inputModel.HotelId,
                AvailableSeats = inputModel.AvailableSeats,
                Transport = inputModel.Transport,
                ReservationType = inputModel.ReservationType,
            };

            await this.organizedTripsRepository.AddAsync(trip);
            await this.organizedTripsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var trip = await this.organizedTripsRepository.All()
               .FirstOrDefaultAsync(x => x.Id == id);

            this.organizedTripsRepository.Delete(trip);

            await this.organizedTripsRepository.SaveChangesAsync();
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair()
        {
            return this.organizedTripsRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).OrderBy(x => x.Value);
        }

        public async Task<IEnumerable<OrganizedTripViewModel>> GetAllAsync()
        {
            var trips = await this.organizedTripsRepository.All().OrderBy(x => x.Name).To<OrganizedTripViewModel>().ToListAsync();

            return trips;
        }

        public async Task<IEnumerable<OrganizedTripViewModel>> GetAllByDestinationIdAsync(int destinationId)
        {
            return await this.organizedTripsRepository.All()
                .Where(x => x.DestinationId == destinationId)
                .Distinct()
                .OrderBy(x => x.Name)
                .To<OrganizedTripViewModel>()
                .ToListAsync();
        }

        public async Task<OrganizedTripViewModel> GetByIdAsync(string id)
        {
            var trip = await this.organizedTripsRepository.All()
                .Where(x => x.Id == id)
                .To<OrganizedTripViewModel>()
                .FirstOrDefaultAsync();

            return trip;
        }
    }
}
