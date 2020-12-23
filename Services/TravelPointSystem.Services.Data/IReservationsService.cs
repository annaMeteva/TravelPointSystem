namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using TravelPointSystem.Web.ViewModels.Reservations;

    public interface IReservationsService
    {
        Task<IEnumerable<ReservationViewModel>> GetAllReservationsByUserIdAsync(string userId);

        Task CreateAsync(ReservationCreateInputModel input, string userId);

        Task<ReservationViewModel> GetByIdAsync(string id);

        int GetAllNotAcceptedReservationsCount();

        int GetAllReservationsCount();

        IEnumerable<ReservationViewModel> GetLastest5Reservations();

        Task<IEnumerable<ReservationViewModel>> GetAllAsync();

        Task DeleteAsync(string id);

        Task EditAsync(ReservationViewModel input, string id);

        bool Exists(string id);
    }
}
