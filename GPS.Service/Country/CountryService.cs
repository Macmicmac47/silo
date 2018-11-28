using System;
using System.Collections.Generic;
using System.Text;
using GPS.Core.Domain;
using GPS.Data;

namespace GPS.Service.Country
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Core.Domain.Country> _repository;

        public CountryService (IRepository<Core.Domain.Country> repository)
        {
            this._repository = repository;
        }

        public IEnumerable<Core.Domain.Country> GetCountries()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Core.Domain.Country> GetCountrybyId(long id)
        {
            return _repository.GetQueryable(id);
        }
    }
}
