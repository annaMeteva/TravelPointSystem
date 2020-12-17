namespace TravelPointSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelPointSystem.Services.Data;

    using TravelPointSystem.Web.ViewModels.Hotels;

    public class HotelsController : BaseController
    {
        private readonly IHotelsService hotelsService;
        private readonly IDestinationsService destinationsService;

        public HotelsController(IHotelsService hotelsService, IDestinationsService destinationsService)
        {
            this.hotelsService = hotelsService;
            this.destinationsService = destinationsService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult CheckDestinationId()
        {
            var inputModel = new HotelsByDestinationIdInputModel();
            inputModel.DestinationItems = this.destinationsService.GetAllCountriesForHotelsAsKeyValuePairs();

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CheckDestinationId(HotelsByDestinationIdInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.DestinationItems = this.destinationsService.GetAllCountriesForHotelsAsKeyValuePairs();
                return this.View(inputModel);
            }

            return this.RedirectToAction("AllByDestinationId", new { destinationId = int.Parse(inputModel.DestinationId) });
        }

        [Authorize]
        [HttpGet]
        public IActionResult AllByDestinationId(int destinationId)
        {
            var hotels = new HotelsByDestinationIdListViewModel
            {
                Hotels = this.hotelsService.GetAllByDestinationId(destinationId),
            };

            return this.View(hotels);
        }

        [Authorize]
        [HttpGet]
        public IActionResult ById(int id)
        {
            var hotel = this.hotelsService.GetById(id);

            return this.View(hotel);
        }
    }
}
