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
        private readonly IReservationsService reservationService;
        private readonly IUsersService usersService;
        private readonly UserManager<ApplicationUser> userManager;

        public ReservationsController(IReservationsService reservationService, IUsersService usersService, UserManager<ApplicationUser> userManager)
        {
            this.reservationService = reservationService;
            this.usersService = usersService;
            this.userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create(ReservationType reservationType, string id, int numberOfTourists)
        {
            var inputModel = new ReservationCreateInputModel
            {
                ReservationType = reservationType,
                NumberOfTourists = numberOfTourists,
                ProductId = id,
            };

            return this.View(inputModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ReservationCreateInputModel inputModel, string id)
        {
            if (!this.ModelState.IsValid)
            {
                inputModel.ProductId = id;
                return this.View(inputModel);
            }

            var userId = this.userManager.GetUserId(this.User);
            inputModel.ProductId = id;

            try
            {
                await this.reservationService.CreateAsync(inputModel, userId);
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                return this.View(inputModel);
            }

            return this.Redirect("/");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ById(string id)
        {
            var reservation = await this.reservationService.GetByIdAsync(id);

            return this.View(reservation);
        }
    }
}
