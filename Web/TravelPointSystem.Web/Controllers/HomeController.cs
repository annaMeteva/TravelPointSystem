namespace TravelPointSystem.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TravelPointSystem.Services.Data;
    using TravelPointSystem.Web.ViewModels;
    using TravelPointSystem.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IDestinationsService destinationsService;
        private readonly IUsersService usersService;
        private readonly IReservationService reservationService;

        public HomeController(IDestinationsService destinationsService, IUsersService usersService, IReservationService reservationService)
        {
            this.destinationsService = destinationsService;
            this.usersService = usersService;
            this.reservationService = reservationService;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction(nameof(this.IndexLoggedIn));
            }

            var viewModel = this.destinationsService.GetDestinationsCount();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet]
        [Route("/Home")]
        public IActionResult IndexLoggedIn()
        {
            var userViewModel = this.usersService.GetUserCompanyName(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var indexLoggedInViewModel = new IndexLoggedInViewModel
            {
                CurrentUser = userViewModel,
                Reservations = this.reservationService.GetAllReservationsByUserId(this.User.FindFirstValue(ClaimTypes.NameIdentifier)),
            };

            if (indexLoggedInViewModel.Reservations.Count() == 0)
            {
                return this.View("NoResult", indexLoggedInViewModel);
            }
            else
            {
                return this.View(indexLoggedInViewModel);
            }
        }

        public IActionResult About()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult HttpError(int statusCode)
        {
            if (statusCode == 404)
            {
                return this.View("NotFoundError");
            }
            else if (statusCode == 500)
            {
                return this.View("InternalServerError");
            }

            return this.View("Error");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
