namespace TravelPointSystem.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Data.Models.Enums;
    using TravelPointSystem.Services.Data;
    using TravelPointSystem.Web.ViewModels.Home;
    using TravelPointSystem.Web.ViewModels.Reservations;

    public class ReservationsController : BaseController
    {
        private readonly IReservationService reservationService;
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;

        public ReservationsController(IReservationService reservationService, IUsersService usersService, UserManager<ApplicationUser> userManager)
        {
            this.reservationService = reservationService;
            this.usersService = usersService;
            this.userManager = userManager;
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
            var userId = this.userManager.GetUserId(this.User);

            try
            {
                await this.reservationService.CreateAsync(inputModel, userId);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                inputModel.ReservationType = reservationType;
                inputModel.ProductId = id;
                return this.View(inputModel);
            }

            var userViewModel = this.usersService.GetUserCompanyName(userId);
            var viewModel = new IndexLoggedInViewModel
            {
                CurrentUser = userViewModel,
                Reservations = this.reservationService.GetAllReservationsByUserId(userId),
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
