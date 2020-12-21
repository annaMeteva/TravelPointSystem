namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TravelPointSystem.Web.ViewModels.Home;
    using TravelPointSystem.Web.ViewModels.Users;

    public interface IUsersService
    {
        UserViewModel GetUserCompanyName(string userId);

        int GetUsersCount();
    }
}
