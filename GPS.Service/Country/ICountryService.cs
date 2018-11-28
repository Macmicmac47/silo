using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Service.Country
{
    public interface ICountryService
    {
        IEnumerable<Core.Domain.Country> GetCountries();
        IEnumerable<Core.Domain.Country> GetCountrybyId(long id);
    }
}
