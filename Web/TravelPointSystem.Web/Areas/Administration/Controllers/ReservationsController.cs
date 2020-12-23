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
    using TravelPointSystem.Web.ViewModels.Reservations;

    public class ReservationsController : AdministrationController
    {
        private readonly IReservationsService reservationsService;

        public ReservationsController(IReservationsService reservationsService)
        {
            this.reservationsService = reservationsService;
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

            var reservation = await this.reservationsService.GetByIdAsync(id);
            if (reservation == null)
            {
                return this.NotFound();
            }

            return this.View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, ReservationViewModel reservationViewModel)
        {
            if (id != reservationViewModel.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(reservationViewModel);
            }

            try
            {
                await this.reservationsService.EditAsync(reservationViewModel, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ReservationExists(reservationViewModel.Id))
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
            return this.reservationsService.Exists(id);
        }
    }
}
