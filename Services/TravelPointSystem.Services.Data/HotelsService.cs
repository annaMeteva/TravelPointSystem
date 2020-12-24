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
            var hotels = await this.hotelsRepository.All().OrderBy(x => x.Name).To<HotelViewModel>().ToListAsync();

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

        public async Task<IEnumerable<HotelViewModel>> GetAllByDestinationIdAsync(int destinationId)
        {
            return await this.hotelsRepository.All()
                .Where(x => x.DestinationId == destinationId)
                .OrderBy(x => x.Name)
                .To<HotelViewModel>()
                .ToListAsync();
        }

        public async Task<HotelViewModel> GetByIdAsync(int? id)
        {
            var hotel = await this.hotelsRepository.All()
                .Where(x => x.Id == id)
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
            };

            await this.hotelsRepository.AddAsync(hotel);
            await this.hotelsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hotel = await this.hotelsRepository.All()
               .FirstOrDefaultAsync(x => x.Id == id);

            this.hotelsRepository.Delete(hotel);

            await this.hotelsRepository.SaveChangesAsync();
        }

        public IEnumerable<HotelViewModel> GetAll()
        {
            return this.hotelsRepository.All().To<HotelViewModel>();
        }

        public async Task EditAsync(int id, HotelViewModel input)
        {
            var hotel = this.hotelsRepository.All().FirstOrDefault(x => x.Id == id);

            hotel.Name = input.Name;
            hotel.ImageUrl = input.ImageUrl;
            hotel.Description = input.Description;
            hotel.Address = input.Address;
            hotel.DestinationId = input.DestinationId;
            hotel.PricePerNightPerPerson = input.PricePerNightPerPerson;
            hotel.Stars = input.Stars;
            hotel.AvailableRooms = input.AvailableRooms;
            hotel.FeedingType = input.FeedingType;
            hotel.IsDeleted = input.IsDeleted;


            this.hotelsRepository.Update(hotel);
            await this.hotelsRepository.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return this.hotelsRepository.All().Any(e => e.Id == id);
        }

        public int GetHotelsCount()
        {
            return this.hotelsRepository.All().Count();
        }
    }
}
