namespace TravelPointSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelPointSystem.Services.Data;
    using TravelPointSystem.Web.ViewModels.Flights;

    public class FlightsController : BaseController
    {
        private readonly IDestinationsService destinationsService;
        private readonly IFlightsService flightsService;

        public FlightsController(IDestinationsService destinationsService, IFlightsService flightsService)
        {
            this.destinationsService = destinationsService;
            this.flightsService = flightsService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult CheckDestinationsId()
        {
            var inputModel = new FlightsByDestinationsIdInputModel();
            inputModel.StartDestinationItems = this.destinationsService.GetAllStartCountriesForFlightsAsKeyValuePairs();
            inputModel.EndDestinationItems = this.destinationsService.GetAllEndCountriesForFlightsAsKeyValuePairs();

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CheckDestinationsId(FlightsByDestinationsIdInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.StartDestinationItems = this.destinationsService.GetAllStartCountriesForFlightsAsKeyValuePairs();
                inputModel.EndDestinationItems = this.destinationsService.GetAllEndCountriesForFlightsAsKeyValuePairs();
            }

            return this.RedirectToAction("AllByDestinationsId", new { startDestinationId = inputModel.StartPointId, endDestinationId = inputModel.EndPointId, numberOfTourists = inputModel.NumberOfTourists });
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> AllByDestinationsId(int startDestinationId, int endDestinationId, int numberOfTourists)
        {
            var flights = new FlightsByDestinationsIdListViewModel
            {
                Flights = await this.flightsService.GetAllByDestinationsIdAsync(startDestinationId, endDestinationId),
                NumberOfTourists = numberOfTourists,
            };

            if (flights.Flights.Count() == 0)
            {
                return this.View("NoResult");
            }
            else
            {
                return this.View(flights);
            }
        }
    }
}
