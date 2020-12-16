namespace TravelPointSystem.Web.Controllers
{
    using System.Diagnostics;
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

        public HomeController(IDestinationsService destinationsService, IUsersService usersService)
        {
            this.destinationsService = destinationsService;
            this.usersService = usersService;
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
            var viewModel = this.usersService.GetUserCompanyName(this.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return this.View(viewModel);
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
