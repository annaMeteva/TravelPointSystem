namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using TravelPointSystem.Web.ViewModels.Home;

    public interface IDestinationsService
    {
        IndexViewModel GetDestinationsCount();
    }
}
