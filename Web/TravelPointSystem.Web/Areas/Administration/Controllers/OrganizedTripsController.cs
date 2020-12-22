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
    using TravelPointSystem.Web.ViewModels.OrganizedTrips;

    public class OrganizedTripsController : AdministrationController
    {
        private readonly IOrganizedTripsService tripsService;
        private readonly IDeletableEntityRepository<OrganizedTrip> tripRepository;
        private readonly IHotelsService hotelsService;
        private readonly IDestinationsService destinationsService;

        public OrganizedTripsController(IOrganizedTripsService tripsService, IDeletableEntityRepository<OrganizedTrip> tripRepository, IHotelsService hotelsService, IDestinationsService destinationsService)
        {
            this.tripsService = tripsService;
            this.tripRepository = tripRepository;
            this.hotelsService = hotelsService;
            this.destinationsService = destinationsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var trips = await this.tripsService.GetAllAsync();
            return this.View(trips);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var organizedTrip = await this.tripsService.GetByIdAsync(id);
            if (organizedTrip == null)
            {
                return this.NotFound();
            }

            return this.View(organizedTrip);
        }

        [HttpGet]
        public IActionResult Create()
        {
            this.ViewData["DestinationId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town");
            this.ViewData["HotelId"] = new SelectList(this.hotelsService.GetAll(), "Id", "Name");
            var inputModel = new OrganizedTripInputModel();

            return this.View(inputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrganizedTripInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewData["DestinationId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", inputModel.DestinationId);
                this.ViewData["HotelId"] = new SelectList(this.hotelsService.GetAll(), "Id", "Name", inputModel.HotelId);
                return this.View(inputModel);
            }

            await this.tripsService.CreateAsync(inputModel);
            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var organizedTrip = await this.tripRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            if (organizedTrip == null)
            {
                return this.NotFound();
            }

            this.ViewData["DestinationId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", organizedTrip.DestinationId);
            this.ViewData["HotelId"] = new SelectList(this.hotelsService.GetAllAsKeyValuePairs(), organizedTrip.HotelId);
            return this.View(organizedTrip);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,ImageUrl,Description,PricePerPerson,DepartureDateTime,ReturnDateTime,DestinationId,HotelId,Transport,AvailableSeats,ReservationType,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] OrganizedTrip organizedTrip)
        {
            if (id != organizedTrip.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                this.ViewData["DestinationId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", organizedTrip.DestinationId);
                this.ViewData["HotelId"] = new SelectList(this.hotelsService.GetAllAsKeyValuePairs(), organizedTrip.HotelId);
                return this.View(organizedTrip);
            }

            try
            {
                this.tripRepository.Update(organizedTrip);
                await this.tripRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.OrganizedTripExists(organizedTrip.Id))
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

            var organizedTrip = await this.tripsService.GetByIdAsync(id);
            if (organizedTrip == null)
            {
                return this.NotFound();
            }

            return this.View(organizedTrip);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await this.tripsService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool OrganizedTripExists(string id)
        {
            return this.tripRepository.All().Any(e => e.Id == id);
        }
    }
}
