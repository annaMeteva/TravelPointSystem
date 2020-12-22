﻿namespace TravelPointSystem.Web.Areas.Administration.Controllers
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
    using TravelPointSystem.Web.ViewModels.Flights;

    public class FlightsController : AdministrationController
    {
        private readonly IFlightsService flightsService;
        private readonly IDestinationsService destinationsService;
        private readonly IDeletableEntityRepository<Flight> flightsRepository;
        private readonly IFlightCompaniesService flightCompaniesService;

        public FlightsController(IFlightsService flightsService, IDestinationsService destinationsService, IDeletableEntityRepository<Flight> flightsRepository, IFlightCompaniesService flightCompaniesService)
        {
            this.flightsService = flightsService;
            this.destinationsService = destinationsService;
            this.flightsRepository = flightsRepository;
            this.flightCompaniesService = flightCompaniesService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var flights = this.flightsService.GetAllAsync();
            return this.View(await flights);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var flight = await this.flightsService.GetByIdAsync(id);
            if (flight == null)
            {
                return this.NotFound();
            }

            return this.View(flight);
        }

        [HttpGet]
        public IActionResult Create()
        {
            this.ViewData["CompanyId"] = new SelectList(this.flightCompaniesService.GetAll(), "Id", "Name");
            this.ViewData["EndPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town");
            this.ViewData["StartPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town");

            var inputModel = new FlightInputModel();
            return this.View(inputModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlightInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewData["CompanyId"] = new SelectList(this.flightCompaniesService.GetAll(), "Id", "Name", inputModel.CompanyId);
                this.ViewData["EndPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", inputModel.EndPointId);
                this.ViewData["StartPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", inputModel.StartPointId);
                return this.View(inputModel);
            }

            await this.flightsService.CreateAsync(inputModel);
            return this.RedirectToAction(nameof(this.Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var flight = await this.flightsRepository.All().FirstOrDefaultAsync(x => x.Id == id);
            if (flight == null)
            {
                return this.NotFound();
            }

            this.ViewData["CompanyId"] = new SelectList(this.flightCompaniesService.GetAll(), "Id", "Name", flight.CompanyId);
            this.ViewData["EndPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", flight.EndPointId);
            this.ViewData["StartPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Town", flight.StartPointId);

            return this.View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FlightNumber,PricePerPerson,CompanyId,DepartureDateTime,FlightTime,StartPointId,StartPointAirPort,EndPointId,EndPointAirPort,AvailableSeats,ReservationType,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Flight flight)
        {
            if (id != flight.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                this.ViewData["CompanyId"] = new SelectList(this.flightCompaniesService.GetAll(), "Id", "Name", flight.CompanyId);
                this.ViewData["EndPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Continent", flight.EndPointId);
                this.ViewData["StartPointId"] = new SelectList(this.destinationsService.GetAll(), "Id", "Continent", flight.StartPointId);

                return this.View(flight);
            }

            try
            {
                this.flightsRepository.Update(flight);
                await this.flightsRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.FlightExists(flight.Id))
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

            var flight = await this.flightsService.GetByIdAsync(id);
            if (flight == null)
            {
                return this.NotFound();
            }

            return this.View(flight);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await this.flightsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.Index));
        }

        private bool FlightExists(string id)
        {
            return this.flightsRepository.All().Any(e => e.Id == id);
        }
    }
}
