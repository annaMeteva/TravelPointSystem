namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Reservations;

    public class ReservationService : IReservationService
    {
        private readonly IDeletableEntityRepository<Reservation> reservationRepository;
        private readonly IDeletableEntityRepository<Hotel> hotelRepository;
        private readonly IDeletableEntityRepository<Flight> flightRepository;
        private readonly IDeletableEntityRepository<Bus> busRepository;
        private readonly IDeletableEntityRepository<OrganizedTrip> organizedTripRepository;
        private readonly IDeletableEntityRepository<Tourist> touristRepository;

        public ReservationService(IDeletableEntityRepository<Reservation> reservationRepository, IDeletableEntityRepository<Hotel> hotelRepository, IDeletableEntityRepository<Flight> flightRepository, IDeletableEntityRepository<Bus> busRepository, IDeletableEntityRepository<OrganizedTrip> organizedTripRepository, IDeletableEntityRepository<Tourist> touristRepository)
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
                IsPaid = false,
                IsAccepted = false,
                CreatorId = userId,
            };

            double productPrice = 0;

            if (input.ReservationType.ToString() == "Flight")
            {
                productPrice = this.flightRepository.All()
                    .FirstOrDefault(x => x.Id == input.ProductId)
                    .PricePerPerson;

                reservation.DestinationId = this.flightRepository.All()
                    .FirstOrDefault(x => x.Id == input.ProductId).EndPointId;

                reservation.Departure = this.flightRepository.All()
                    .FirstOrDefault(x => x.Id == input.ProductId)
                    .DepartureDateTime;

                reservation.FlightId = input.ProductId;
            }
            else if (input.ReservationType.ToString() == "Bus")
            {
                productPrice = this.busRepository.All()
                    .FirstOrDefault(x => x.Id == input.ProductId)
                    .PricePerPerson;

                reservation.DestinationId = this.busRepository.All()
                    .FirstOrDefault(x => x.Id == input.ProductId).EndPointId;

                reservation.Departure = this.busRepository.All()
                    .FirstOrDefault(x => x.Id == input.ProductId)
                    .DepartureDateTime;

                reservation.BusId = input.ProductId;
            }
            else if (input.ReservationType.ToString() == "OrganizedTrip")
            {
                productPrice = this.organizedTripRepository.All()
                    .FirstOrDefault(x => x.Id == input.ProductId)
                    .PricePerPerson;

                reservation.DestinationId = this.organizedTripRepository.All()
                    .FirstOrDefault(x => x.Id == input.ProductId).DestinationId;

                reservation.Departure = this.organizedTripRepository.All()
                    .FirstOrDefault(x => x.Id == input.ProductId)
                    .DepartureDateTime;

                reservation.Return = this.organizedTripRepository.All()
                    .FirstOrDefault(x => x.Id == input.ProductId)
                    .ReturnDateTime;

                reservation.OrganizedTripId = input.ProductId;
            }
            else if (input.ReservationType.ToString() == "Hotel")
            {
                productPrice = this.hotelRepository.All()
                    .FirstOrDefault(x => x.Id.ToString() == input.ProductId)
                    .PricePerNightPerPerson;

                reservation.DestinationId = this.hotelRepository.All()
                    .FirstOrDefault(x => x.Id.ToString() == input.ProductId).DestinationId;

                reservation.HotelId = int.Parse(input.ProductId);
                reservation.Departure = input.CheckIn + new TimeSpan(14, 00, 00);
                reservation.Return = input.CheckOut + new TimeSpan(12, 00, 00);
                productPrice *= (input.CheckOut - input.CheckIn).Days;
            }

            foreach (var inputTourist in input.Tourists)
            {
                reservation.Tourists.Add(new Tourist { FullName = inputTourist.FullName, DateOfBirth = inputTourist.DateOfBirth, TouristType = inputTourist.TouristType, PersonalNumber = inputTourist.PersonalNumber, PassportNumber = inputTourist.PassportNumber, PhoneNumber = inputTourist.PhoneNumber });
            }

            reservation.Price = productPrice * reservation.Tourists.Count();
            reservation.Profit = Math.Round(0.1 * productPrice, 2);

            await this.reservationRepository.AddAsync(reservation);
            await this.reservationRepository.SaveChangesAsync();
        }

        public int GetAllNotAcceptedReservationsCount()
        {
            return this.reservationRepository.All()
                .Where(x => x.IsAccepted == false)
                .Count();
        }

        public IEnumerable<ReservationViewModel> GetAllReservationsByUserId(string userId)
        {
            return this.reservationRepository.All()
                .Where(r => r.CreatorId == userId)
                .OrderByDescending(r => r.CreatedOn)
                .To<ReservationViewModel>();
        }

        public int GetAllReservationsCount()
        {
            return this.reservationRepository.All().Count();
        }

        public ReservationViewModel GetById(string id)
        {
            return this.reservationRepository.All()
                .Where(x => x.Id == id)
                .To<ReservationViewModel>()
                .FirstOrDefault();
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
