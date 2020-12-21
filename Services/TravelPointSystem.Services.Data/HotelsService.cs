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
    using TravelPointSystem.Web.ViewModels.Hotels;

    public class HotelsService : IHotelsService
    {
        private readonly IDeletableEntityRepository<Hotel> hotelsRepository;

        public HotelsService(IDeletableEntityRepository<Hotel> hotelsRepository)
        {
            this.hotelsRepository = hotelsRepository;
        }

        public async Task<IEnumerable<HotelViewModel>> GetAllAsync()
        {
            var hotels = await this.hotelsRepository.All().OrderBy(h => h.Name).To<HotelViewModel>().ToListAsync();

            return hotels;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.hotelsRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).OrderBy(x => x.Value);
        }

        public IEnumerable<HotelViewModel> GetAllByDestinationId(int destinationId)
        {
            return this.hotelsRepository.All()
                .Where(h => h.DestinationId == destinationId)
                .OrderBy(h => h.Name)
                .To<HotelViewModel>();
        }

        public async Task<HotelViewModel> GetByIdAsync(int? id)
        {
            var hotel = await this.hotelsRepository.All()
                .Where(h => h.Id == id)
                .To<HotelViewModel>().FirstOrDefaultAsync();

            return hotel;
        }

        public async Task CreateAsync(HotelInputModel inputModel)
        {
            var hotel = new Hotel
            {
                Name = inputModel.Name,
                ImageUrl = inputModel.ImageUrl,
                Description = inputModel.Description,
                Address = inputModel.Address,
                DestinationId = inputModel.DestinationId,
                PricePerNightPerPerson = inputModel.PricePerNightPerPerson,
                Stars = inputModel.Stars,
                AvailableRooms = inputModel.AvailableRooms,
                ReservationType = inputModel.ReservationType,
                FeedingType = inputModel.FeedingType,
                CreatedOn = DateTime.UtcNow,
                DeletedOn = inputModel.DeletedOn,
                IsDeleted = inputModel.IsDeleted,
            };

            await this.hotelsRepository.AddAsync(hotel);
            await this.hotelsRepository.SaveChangesAsync();
        }
    }
}
