namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Web.ViewModels.Home;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IndexLoggedInViewModel GetUserCompanyName(string userId)
        {
            var companyName = new IndexLoggedInViewModel()
            {
                CompanyName = this.usersRepository.All().FirstOrDefault(u => u.Id == userId).CompanyName,
            };

            return companyName;
        }
    }
}
