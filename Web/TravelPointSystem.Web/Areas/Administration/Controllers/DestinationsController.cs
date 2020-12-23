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
    using TravelPointSystem.Web.ViewModels.Destinations;

    public class DestinationsController : AdministrationController
    {
        private readonly IDestinationsService destinationsService;

        public DestinationsController(IDestinationsService destinationsService)
        {
            this.destinationsService = destinationsService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return this.View(await this.destinationsService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var destination = await this.destinationsService.GetByIdAsync(id);
            if (destination == null)
            {
                return this.NotFound();
            }

            return this.View(destination);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var inputModel = new DestinationInputModel();
            return this.View(inputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DestinationInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.destinationsService.CreateAsync(inputModel);
            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var destination = await this.destinationsService.GetByIdAsync(id);
            if (destination == null)
            {
                return this.NotFound();
            }

            return this.View(destination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DestinationViewModel destinationViewModel)
        {
            if (id != destinationViewModel.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(destinationViewModel);
            }

            try
            {
                await this.destinationsService.EditAsync(id, destinationViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.DestinationExists(destinationViewModel.Id))
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var destination = await this.destinationsService.GetByIdAsync(id);
            if (destination == null)
            {
                return this.NotFound();
            }

            return this.View(destination);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.destinationsService.DeleteAsync(id);
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool DestinationExists(int id)
        {
            return this.destinationsService.Exists(id);
        }
    }
}
