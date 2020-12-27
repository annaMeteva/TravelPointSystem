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
    using TravelPointSystem.Web.ViewModels.Reservations;

    public class ReservationsService : IReservationsService
    {
        private readonly IDeletableEntityRepository<Reservation> reservationRepository;
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;
        private readonly IDeletableEntityRepository<Flight> flightRepository;
        private readonly IDeletableEntityRepository<Bus> busRepository;
        private readonly IDeletableEntityRepository<OrganizedTrip> organizedTripRepository;
        private readonly IDeletableEntityRepository<Tourist> touristRepository;

        public ReservationsService(IDeletableEntityRepository<Reservation> reservationRepository, IDeletableEntityRepository<Hotel> hotelRepository, IDeletableEntityRepository<Flight> flightRepository, IDeletableEntityRepository<Bus> busRepository, IDeletableEntityRepository<OrganizedTrip> organizedTripRepository, IDeletableEntityRepository<Tourist> touristRepository)
        {
            this.reservationRepository = reservationRepository;
            this.hotelRepository = hotelRepository;
            this.flightRepository = flightRepository;
            this.busRepository = busRepository;
            this.organizedTripRepository = organizedTripRepository;
            this.touristRepository = touristRepository;
        }

        public async Task CreateAsync(ReservationCreateInputModel input, string userId)
        {
            var reservation = new Reservation
            {
                ReservationType = input.ReservationType,
                Balance = 0,
                IsAccepted = false,
                CreatorId = userId,
            };

            double productPricePerAdult = 0;

            if (input.ReservationType.ToString() == "Flight")
            {
                var flight = await this.flightRepository.All().FirstOrDefaultAsync(x => x.Id == input.ProductId);

                if (flight.AvailableSeats != 0)
                {
                    flight.AvailableSeats--;
                    await this.flightRepository.SaveChangesAsync();
                }

                productPricePerAdult = flight.PricePerPerson;

                reservation.DestinationId = flight.EndPointId;

                reservation.Departure = flight.DepartureDateTime;

                reservation.FlightId = input.ProductId;
            }
            else if (input.ReservationType.ToString() == "Bus")
            {
                var bus = await this.busRepository.All()
                    .FirstOrDefaultAsync(x => x.Id == input.ProductId);

                if (bus.AvailableSeats != 0)
                {
                    bus.AvailableSeats--;
                    await this.busRepository.SaveChangesAsync();
                }

                productPricePerAdult = bus.PricePerPerson;

                reservation.DestinationId = bus.EndPointId;

                reservation.Departure = bus.DepartureDateTime;

                reservation.BusId = input.ProductId;
            }
            else if (input.ReservationType.ToString() == "OrganizedTrip")
            {
                var organizedTrip = await this.organizedTripRepository.All()
                    .FirstOrDefaultAsync(x => x.Id == input.ProductId);

                if (organizedTrip.AvailableSeats != 0)
                {
                    organizedTrip.AvailableSeats--;
                    await this.organizedTripRepository.SaveChangesAsync();
                }

                productPricePerAdult = organizedTrip.PricePerPerson;

                reservation.DestinationId = organizedTrip.DestinationId;

                reservation.Departure = organizedTrip.DepartureDateTime;

                reservation.Return = organizedTrip.ReturnDateTime;

                reservation.OrganizedTripId = input.ProductId;
            }
            else if (input.ReservationType.ToString() == "Hotel")
            {
                var hotel = await this.hotelRepository.All()
                    .FirstOrDefaultAsync(x => x.Id.ToString() == input.ProductId);

                if (hotel.AvailableRooms != 0)
                {
                    hotel.AvailableRooms--;
                    await this.hotelRepository.SaveChangesAsync();
                }

                productPricePerAdult = hotel.PricePerNightPerPerson;

                reservation.DestinationId = hotel.DestinationId;

                reservation.HotelId = int.Parse(input.ProductId);
                reservation.Departure = input.CheckIn + new TimeSpan(14, 00, 00);
                reservation.Return = input.CheckOut + new TimeSpan(12, 00, 00);
                productPricePerAdult *= (input.CheckOut - input.CheckIn).Days;
            }

            foreach (var inputTourist in input.Tourists)
            {
                reservation.Tourists.Add(new Tourist { FullName = inputTourist.FullName, DateOfBirth = inputTourist.DateOfBirth, TouristType = inputTourist.TouristType, PersonalNumber = inputTourist.PersonalNumber, PassportNumber = inputTourist.PassportNumber, PhoneNumber = inputTourist.PhoneNumber });
            }


            double productPricePerChild = Math.Round(productPricePerAdult / 2, 2);
            var childs = reservation.Tourists.Where(x => x.TouristType.ToString() == "Child").Count();
            var adults = reservation.Tourists.Count();
            if (childs != 0)
            {
                reservation.Price = productPricePerChild * childs;
                reservation.Price += productPricePerAdult * (adults - childs);
            }
            else
            {
                reservation.Price = productPricePerAdult * adults;
            }

            reservation.Profit = Math.Round(0.1 * reservation.Price, 2);

            await this.reservationRepository.AddAsync(reservation);
            await this.reservationRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var reservation = await this.reservationRepository.All()
                .FirstOrDefaultAsync(x => x.Id == id);

            var tourists = await this.touristRepository.All()
                .Where(x => x.ReservationId == id)
                .ToListAsync();

            foreach (var tourist in tourists)
            {
                this.touristRepository.Delete(tourist);
            }

            this.reservationRepository.Delete(reservation);

            await this.touristRepository.SaveChangesAsync();
            await this.reservationRepository.SaveChangesAsync();
        }

        public async Task EditAsync(ReservationViewModel input, string id)
        {
            var reservation = this.reservationRepository.All().Include(x => x.Tourists).FirstOrDefault(x => x.Id == id);
            var tourists = reservation.Tourists;

            foreach (var tourist in tourists)
            {
                var updatedTourist = input.Tourists.FirstOrDefault(x => x.Id == tourist.Id);
                tourist.FullName = updatedTourist.FullName;
                tourist.DateOfBirth = updatedTourist.DateOfBirth;
                tourist.PersonalNumber = updatedTourist.PersonalNumber;
                tourist.PassportNumber = updatedTourist.PassportNumber;
                tourist.PhoneNumber = updatedTourist.PhoneNumber;
                tourist.TouristType = updatedTourist.TouristType;

                this.touristRepository.Update(tourist);
                await this.reservationRepository.SaveChangesAsync();
            }

            reservation.Price = input.Price;
            reservation.Balance = input.Balance;
            reservation.Profit = input.Profit;
            reservation.IsAccepted = input.IsAccepted;
            reservation.IsDeleted = input.IsDeleted;

            this.reservationRepository.Update(reservation);
            await this.reservationRepository.SaveChangesAsync();
        }

        public bool Exists(string id)
        {
            return this.reservationRepository.All().Any(e => e.Id == id);
        }

        public async Task<IEnumerable<ReservationViewModel>> GetAllAsync()
        {
            return await this.reservationRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .To<ReservationViewModel>()
                .ToListAsync();
        }

        public int GetAllNotAcceptedReservationsCount()
        {
            return this.reservationRepository.All()
                .Where(x => x.IsAccepted == false)
                .Count();
        }

        public async Task<IEnumerable<ReservationViewModel>> GetAllReservationsByUserIdAsync(string userId)
        {
            return await this.reservationRepository.All()
                .Where(x => x.CreatorId == userId)
                .OrderByDescending(x => x.CreatedOn)
                .To<ReservationViewModel>()
                .ToListAsync();
        }

        public int GetAllReservationsCount()
        {
            return this.reservationRepository.All().Count();
        }

        public async Task<ReservationViewModel> GetByIdAsync(string id)
        {
            return await this.reservationRepository.All()
                .Where(x => x.Id == id)
                .To<ReservationViewModel>()
                .FirstOrDefaultAsync();
        }

        public IEnumerable<ReservationViewModel> GetLastest5Reservations()
        {
            return this.reservationRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Take(5)
                .To<ReservationViewModel>();
        }
    }
}
