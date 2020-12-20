namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TravelPointSystem.Web.ViewModels.Reservations;

    public interface IReservationService
    {
        IEnumerable<ReservationViewModel> GetAllReservationsByUserId(string userId);

        Task CreateAsync(ReservationCreateInputModel input, string userId);

        ReservationViewModel GetById(string id);

    }
}
