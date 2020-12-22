namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TravelPointSystem.Data.Common.Repositories;
    using TravelPointSystem.Data.Models;
    using TravelPointSystem.Services.Mapping;
    using TravelPointSystem.Web.ViewModels.Home;
    using TravelPointSystem.Web.ViewModels.Users;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public UserViewModel GetUserCompanyName(string userId)
        {
            var userViewModel = new UserViewModel
            {
                CompanyName = this.usersRepository.All().FirstOrDefault(x => x.Id == userId).CompanyName,
            };

            return userViewModel;
        }

        public int GetUsersCount()
        {
            return this.usersRepository.All().Count();
        }
    }
}
