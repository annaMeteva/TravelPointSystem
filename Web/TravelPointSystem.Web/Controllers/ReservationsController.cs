namespace TravelPointSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Data;
    using TravelPointSystem.Web.ViewModels.Reservations;

    public class ReservationsController : BaseController
    {
        private readonly IHotelsService hotelsService;
        private readonly IOrganizedTripsService organizedTripsService;
        private readonly IFlightsService flightsService;
        private readonly IBusesService busesService;

        public ReservationsController(IHotelsService hotelsService, IOrganizedTripsService organizedTripsService, IFlightsService flightsService, IBusesService busesService)
        {
            this.hotelsService = hotelsService;
            this.organizedTripsService = organizedTripsService;
            this.flightsService = flightsService;
            this.busesService = busesService;
        }

        public IActionResult Create()
        {
            var inputModel = new ReservationCreateInputModel();
            return this.View(inputModel);
        }

        [HttpPost]
        public IActionResult Create(ReservationCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }


            if (inputModel.ReservationType.ToString() == "Bus")
            {
                return this.RedirectToAction("BusReservationCreate");
            }
            else if (inputModel.ReservationType.ToString() == "Flight")
            {
                return this.RedirectToAction("FlightReservationCreate");
            }
            else if (inputModel.ReservationType.ToString() == "Hotel")
            {
                return this.RedirectToAction("HotelReservationCreate");
            }
            else if (inputModel.ReservationType.ToString() == "OrganizedTrip")
            {
                return this.RedirectToAction("OrganizedTripReservationCreate");
            }

            return this.View();
        }

        public IActionResult BusReservationCreate()
        {
            var inputModel = new BusCreateInputModel();
            inputModel.BusesItems = this.busesService.GetAllAsKeyValuePair();
            return this.View(inputModel);
        }

        [HttpPost]
        public IActionResult BusReservationCreate(BusCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.BusesItems = this.busesService.GetAllAsKeyValuePair();
                return this.View(inputModel);
            }

            return this.View();
        }

        public IActionResult FlightReservationCreate()
        {
            var inputModel = new FlightCreateInputModel();
            inputModel.FlightsItems = this.flightsService.GetAllAsKeyValuePair();
            return this.View(inputModel);
        }

        [HttpPost]
        public IActionResult FlightReservationCreate(FlightCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.FlightsItems = this.flightsService.GetAllAsKeyValuePair();
                return this.View(inputModel);
            }

            // Redirect to reservation info page
            return this.View();
        }

        public IActionResult HotelReservationCreate()
        {
            var inputModel = new HotelCreateInputModel();
            inputModel.HotelsItems = this.hotelsService.GetAllAsKeyValuePairs();
            return this.View(inputModel);
        }

        [HttpPost]
        public IActionResult HotelReservationCreate(HotelCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.HotelsItems = this.hotelsService.GetAllAsKeyValuePairs();
                return this.View(inputModel);
            }

            return this.Json(inputModel);

            // Redirect to reservation info page
            return this.View();
        }

        public IActionResult OrganizedTripReservationCreate()
        {
            var inputModel = new OrganizedTripCreateInputModel();
            inputModel.OrganizedTripsItems = this.organizedTripsService.GetAllAsKeyValuePair();
            return this.View(inputModel);
        }

        [HttpPost]
        public IActionResult OrganizedTripReservationCreate(OrganizedTripCreateInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.OrganizedTripsItems = this.organizedTripsService.GetAllAsKeyValuePair();
                return this.View(inputModel);
            }
            // Redirect to reservation info page
            return this.View();
        }

        public IActionResult TouristReservationCreate()
        {
            var inputModel = new TouristCreateInputModel();
            return this.View(inputModel);
        }

        [HttpPost]
        public IActionResult TouristReservationCreate(TouristCreateInputModel inputModel)
        {

            // Redirect to reservation info page
            return this.View();
        }
    }
}
