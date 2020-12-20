namespace TravelPointSystem.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TravelPointSystem.Web.ViewModels.Reservations;
    using TravelPointSystem.Web.ViewModels.Users;

    public class IndexLoggedInViewModel
    {
        public UserViewModel CurrentUser { get; set; }

        public IEnumerable<ReservationViewModel> Reservations { get; set; }
    }
}
