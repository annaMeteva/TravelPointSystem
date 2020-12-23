namespace TravelPointSystem.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using TravelPointSystem.Services.Data;
    using TravelPointSystem.Web.ViewModels.Administration.Dashboard;

    public class DashboardController : AdministrationController
    {
        private readonly IUsersService usersService;
        private readonly IReservationsService reservationService;

        public DashboardController(IUsersService usersService, IReservationsService reservationService)
        {
            this.usersService = usersService;
            this.reservationService = reservationService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                ReservationsCount = this.reservationService.GetAllReservationsCount(),
                NotAcceptedReservationsCount = this.reservationService.GetAllNotAcceptedReservationsCount(),
                UsersCount = this.usersService.GetUsersCount(),
                Lastest5Reservations = this.reservationService.GetLastest5Reservations(),
            };

            return this.View(viewModel);
        }
    }
}
