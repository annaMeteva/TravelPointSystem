namespace TravelPointSystem.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TravelPointSystem.Common;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Data;
    using TravelPointSystem.Web.ViewModels;
    using TravelPointSystem.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IDestinationsService destinationsService;
        private readonly IUsersService usersService;
        private readonly IReservationsService reservationService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHotelsService hotelsService;

        public HomeController(IDestinationsService destinationsService, IUsersService usersService, IReservationsService reservationService, UserManager<ApplicationUser> userManager, IHotelsService hotelsService)
        {
            this.destinationsService = destinationsService;
            this.usersService = usersService;
            this.reservationService = reservationService;
            this.userManager = userManager;
            this.hotelsService = hotelsService;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            if (this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.RedirectToAction("Index", "Dashboard", new { area = "Administration" });
            }
            else if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("IndexLoggedIn");
            }

            var viewModel = new IndexViewModel
            {
                DestinationsCount = this.destinationsService.GetDestinationsCount(),
                HotelsCount = this.hotelsService.GetHotelsCount(),
            };
            return this.View(viewModel);
        }

        [Authorize]
        [HttpGet]
        [Route("/Home")]
        public async Task<IActionResult> IndexLoggedIn()
        {
            var userId = this.userManager.GetUserId(this.User);

            var userViewModel = this.usersService.GetUserCompanyName(userId);
            var indexLoggedInViewModel = new IndexLoggedInViewModel
            {
                CurrentUser = userViewModel,
                Reservations = await this.reservationService.GetAllReservationsByUserIdAsync(userId),
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
