namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBusesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePair();
    }
}
