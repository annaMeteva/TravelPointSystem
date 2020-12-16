namespace TravelPointSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IHotelsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
