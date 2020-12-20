namespace TravelPointSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Data;
    using TravelPointSystem.Web.ViewModels.Home;
    using TravelPointSystem.Web.ViewModels.Reservations;

    public class ReservationsController : BaseController
    {
        private readonly IReservationService reservationService;
        private readonly IUsersService usersService;

        public ReservationsController(IReservationService reservationService, IUsersService usersService)
        {
            this.reservationService = reservationService;
            this.usersService = usersService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(ReservationType reservationType)
        {
            var inputModel = new ReservationCreateInputModel();
            inputModel.ReservationType = reservationType;

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreateInputModel inputModel, ReservationType reservationType, string id)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.ReservationType = reservationType;
                inputModel.ProductId = id;
                return this.View(inputModel);
            }

            inputModel.ProductId = id;

            try
            {
                await this.reservationService.CreateAsync(inputModel, this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                inputModel.ReservationType = reservationType;
                inputModel.ProductId = id;
                return this.View(inputModel);
            }

            var userViewModel = this.usersService.GetUserCompanyName(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var viewModel = new IndexLoggedInViewModel
            {
                CurrentUser = userViewModel,
                Reservations = this.reservationService.GetAllReservationsByUserId(this.User.FindFirstValue(ClaimTypes.NameIdentifier)),
            };

            return this.Redirect("/");
        }

        [Authorize]
        [HttpGet]
        public IActionResult ById(string id)
        {
            var reservation = this.reservationService.GetById(id);

            return this.View(reservation);
        }
    }
}
