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

            return this.RedirectToAction("AllByDestinationId", new { destinationId = int.Parse(inputModel.DestinationId) });
        }

        [Authorize]
        [HttpGet]
        public IActionResult AllByDestinationId(int destinationId)
        {
            var organizedTrips = new OrganizedTripsByDestinationIdListViewModel
            {
                OrganizedTrips = this.organizedTripsService.GetAllByDestinationId(destinationId),
            };

            return this.View(organizedTrips);
        }

        [Authorize]
        [HttpGet]
        public IActionResult ById(string id)
        {
            var trip = this.organizedTripsService.GetById(id);

            return this.View(trip);
        }
    }
}
