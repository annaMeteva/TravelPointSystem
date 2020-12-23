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
    using TravelPointSystem.Web.ViewModels.FlightCompanies;

    public class FlightCompaniesController : AdministrationController
    {
        private readonly IFlightCompaniesService flightCompaniesService;

        public FlightCompaniesController(IFlightCompaniesService flightCompaniesService)
        {
            this.flightCompaniesService = flightCompaniesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return this.View(await this.flightCompaniesService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var flightCompany = await this.flightCompaniesService.GetByIdAsync(id);
            if (flightCompany == null)
            {
                return this.NotFound();
            }

            return this.View(flightCompany);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var inputModel = new FlightCompanyInputModel();

            return this.View(inputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlightCompanyInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(inputModel);
            }

            await this.flightCompaniesService.CreateAsync(inputModel);

            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var flightCompany = await this.flightCompaniesService.GetByIdAsync(id);
            if (flightCompany == null)
            {
                return this.NotFound();
            }

            return this.View(flightCompany);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FlightCompanyViewModel companyViewModel)
        {
            if (id != companyViewModel.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(companyViewModel);
            }

            try
            {
                await this.flightCompaniesService.EditAsync(id, companyViewModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.FlightCompanyExists(companyViewModel.Id))
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

            var flightCompany = await this.flightCompaniesService.GetByIdAsync(id);
            if (flightCompany == null)
            {
                return this.NotFound();
            }

            return this.View(flightCompany);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            await this.flightCompaniesService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }

        private bool FlightCompanyExists(int id)
        {
            return this.flightCompaniesService.Exists(id);
        }
    }
}
