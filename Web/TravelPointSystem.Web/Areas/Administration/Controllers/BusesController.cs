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
    using TravelPointSystem.Web.ViewModels.Buses;

    public class BusesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Bus> busesRepository;
        private readonly IBusesService busesService;
        private readonly IDestinationsService destinationsService;

        public BusesController(IDeletableEntityRepository<Bus> busesRepository, IBusesService busesService, IDestinationsService destinationsService)
        {
            this.busesRepository = busesRepository;
            this.busesService = busesService;
            this.destinationsService = destinationsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var buses = this.busesService.GetAllAsync();
            return this.View(await buses);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var bus = await this.busesService.GetByIdAsync(id);
            if (bus == null)
            {
                return this.NotFound();
            }

            return this.View(bus);
        }

        [HttpGet]
        public IActionResult Create()
        {
            this.ViewData["EndPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town");
            this.ViewData["StartPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town");

            var inputModel = new BusInputModel();

            return this.View(inputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BusInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewData["EndPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", inputModel.EndPointId);
                this.ViewData["StartPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", inputModel.StartPointId);
                return this.View(inputModel);
            }

            await this.busesService.CreateAsync(inputModel);
            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var bus = await this.busesRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            if (bus == null)
            {
                return this.NotFound();
            }

            this.ViewData["EndPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", bus.EndPointId);
            this.ViewData["StartPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", bus.StartPointId);
            return this.View(bus);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BusNumber,PricePerPerson,DepartureDateTime,TravellingTime,AvailableSeats,StartPointId,StartPointStation,EndPointId,EndPointStation,ReservationType,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Bus bus)
        {
            if (id != bus.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                this.ViewData["EndPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", bus.EndPointId);
                this.ViewData["StartPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", bus.StartPointId);
                return this.View(bus);
            }

            try
            {
                this.busesRepository.Update(bus);
                await this.busesRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.BusExists(bus.Id))
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

            var bus = await this.busesService.GetByIdAsync(id);
            if (bus == null)
            {
                return this.NotFound();
            }

            return this.View(bus);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await this.busesService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }

        private bool BusExists(string id)
        {
            return this.busesRepository.All().Any(e => e.Id == id);
        }
    }
}
