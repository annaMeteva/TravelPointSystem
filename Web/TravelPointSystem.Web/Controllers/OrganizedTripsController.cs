namespace TravelPointSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelPointSystem.Services.Data;
    using TravelPointSystem.Web.ViewModels.OrganizedTrips;

    public class OrganizedTripsController : BaseController
    {
        private readonly IDestinationsService destinationsService;
        private readonly IOrganizedTripsService organizedTripsService;

        public OrganizedTripsController(IDestinationsService destinationsService, IOrganizedTripsService organizedTripsService)
        {
            this.destinationsService = destinationsService;
            this.organizedTripsService = organizedTripsService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult CheckDestinationId()
        {
            var inputModel = new OrganizedTripsByDestinationIdInputModel();
            inputModel.DestinationItems = this.destinationsService.GetAllCountriesForTripsAsKeyValuePairs();
            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CheckDestinationId(OrganizedTripsByDestinationIdInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.DestinationItems = this.destinationsService.GetAllCountriesForTripsAsKeyValuePairs();
            }

            return this.RedirectToAction("AllByDestinationId", new { destinationId = int.Parse(inputModel.DestinationId), numberOfTourists = inputModel.NumberOfTourists });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AllByDestinationId(int destinationId, int numberOfTourists)
        {
            var organizedTrips = new OrganizedTripsByDestinationIdListViewModel
            {
                OrganizedTrips = await this.organizedTripsService.GetAllByDestinationIdAsync(destinationId),
                NumberOfTourists = numberOfTourists,
            };

            if (organizedTrips.OrganizedTrips.Count() == 0)
            {
                return this.View("NoResult");
            }
            else
            {
                return this.View(organizedTrips);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ById(string id, int numberOfTourists)
        {
            var trip = await this.organizedTripsService.GetByIdAsync(id);
            trip.NumberOfTourists = numberOfTourists;

            return this.View(trip);
        }
    }
}
