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
        private readonly IBusesService busesService;
        private readonly IDestinationsService destinationsService;

        public BusesController(IBusesService busesService, IDestinationsService destinationsService)
        {
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

            var bus = await this.busesService.GetByIdAsync(id);
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
        public async Task<IActionResult> Edit(string id, BusViewModel busViewModel)
        {
            if (id != busViewModel.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                this.ViewData["EndPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", busViewModel.EndPointId);
                this.ViewData["StartPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", busViewModel.StartPointId);
                return this.View(busViewModel);
            }

            try
            {
                await this.busesService.EditAsync(id, busViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.BusExists(busViewModel.Id))
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
            return this.busesService.Exists(id);
        }
    }
}
