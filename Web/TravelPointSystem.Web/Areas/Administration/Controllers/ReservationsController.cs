namespace TravelPointSystem.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using TravelPointSystem.Data;
    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Data;

    public class ReservationsController : AdministrationController
    {
        private readonly IReservationsService reservationsService;
        private readonly IDeletableEntityRepository<Reservation> reservationsRepository;
        private readonly IDeletableEntityRepository<Bus> busesRepository;
        private readonly IDeletableEntityRepository<Flight> flightsRepository;
        private readonly IDeletableEntityRepository<Hotel> hotelsRepository;
        private readonly IDeletableEntityRepository<OrganizedTrip> tripsRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Destination> destinationsRepository;

        public ReservationsController(IReservationsService reservationsService, IDeletableEntityRepository<Reservation> reservationsRepository, IDeletableEntityRepository<Bus> busesRepository, IDeletableEntityRepository<Flight> flightsRepository, IDeletableEntityRepository<Hotel> hotelsRepository, IDeletableEntityRepository<OrganizedTrip> tripsRepository, IDeletableEntityRepository<ApplicationUser> usersRepository, IDeletableEntityRepository<Destination> destinationsRepository)
        {
            this.reservationsService = reservationsService;
            this.reservationsRepository = reservationsRepository;
            this.busesRepository = busesRepository;
            this.flightsRepository = flightsRepository;
            this.hotelsRepository = hotelsRepository;
            this.tripsRepository = tripsRepository;
            this.usersRepository = usersRepository;
            this.destinationsRepository = destinationsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var reservations = await this.reservationsService.GetAllAsync();

            return this.View(reservations);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var reservation = await this.reservationsService.GetByIdAsync(id);
            if (reservation == null)
            {
                return this.NotFound();
            }

            return this.View(reservation);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var reservation = await this.reservationsRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            if (reservation == null)
            {
                return this.NotFound();
            }

            this.ViewData["BusId"] = new SelectList(this.busesRepository.All(), "Id", "BusNumber", reservation.BusId);
            this.ViewData["CreatorId"] = new SelectList(this.usersRepository.All(), "Id", "UserName", reservation.CreatorId);
            this.ViewData["DestinationId"] = new SelectList(this.destinationsRepository.All(), "Id", "Town", reservation.DestinationId);
            this.ViewData["FlightId"] = new SelectList(this.flightsRepository.All(), "Id", "FlightNumber", reservation.FlightId);
            this.ViewData["HotelId"] = new SelectList(this.hotelsRepository.All(), "Id", "Name", reservation.HotelId);
            this.ViewData["OrganizedTripId"] = new SelectList(this.tripsRepository.All(), "Id", "Name", reservation.OrganizedTripId);
            return this.View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ReservationType,Price,Balance,Profit,IsPaid,IsAccepted,DestinationId,CreatorId,HotelId,OrganizedTripId,FlightId,BusId,Departure,Return,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                this.ViewData["BusId"] = new SelectList(this.busesRepository.All(), "Id", "BusNumber", reservation.BusId);
                this.ViewData["CreatorId"] = new SelectList(this.usersRepository.All(), "Id", "UserName", reservation.CreatorId);
                this.ViewData["DestinationId"] = new SelectList(this.destinationsRepository.All(), "Id", "Town", reservation.DestinationId);
                this.ViewData["FlightId"] = new SelectList(this.flightsRepository.All(), "Id", "FlightNumber", reservation.FlightId);
                this.ViewData["HotelId"] = new SelectList(this.hotelsRepository.All(), "Id", "Name", reservation.HotelId);
                this.ViewData["OrganizedTripId"] = new SelectList(this.tripsRepository.All(), "Id", "Name", reservation.OrganizedTripId);
                return this.View(reservation);
            }

            try
            {
                this.reservationsRepository.Update(reservation);
                await this.reservationsRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ReservationExists(reservation.Id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var reservation = await this.reservationsService.GetByIdAsync(id);
            if (reservation == null)
            {
                return this.NotFound();
            }

            return this.View(reservation);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await this.reservationsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }

        private bool ReservationExists(string id)
        {
            return this.reservationsRepository.All().Any(e => e.Id == id);
        }
    }
}
