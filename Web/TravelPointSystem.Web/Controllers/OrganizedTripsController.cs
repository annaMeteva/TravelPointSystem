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
            inputModel.DestinationItems = this.destinationsService.GetAllCountriesAsKeyValuePairs();

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CheckDestinationId(OrganizedTripsByDestinationIdInputModel inputModel)
        {
            return this.RedirectToAction("AllByDestinationId", new { destinationId = int.Parse(inputModel.DestinationId) });
        }

        [Authorize]
        [HttpGet]
        public IActionResult AllByDestinationId(int destinationId)
        {
            var organizedTripsViewModel = new OrganizedTripsByDestinationIdListViewModel
            {
                OrganizedTrips = this.organizedTripsService.GetAllByDestinationId(destinationId),
            };

            return this.View(organizedTripsViewModel);
        }
    }
}
