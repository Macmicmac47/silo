using System;
using System.Collections.Generic;
using System.Text;
using GPS.Core.Domain;
using GPS.Data;

namespace GPS.Service.Demographic
{
    public class DemographicService : IDemographicService
    {
        private readonly IRepository<Core.Domain.Demographic> _demographicRepository;

        public DemographicService(IRepository<Core.Domain.Demographic> demographicRepository)
        {
            this._demographicRepository = demographicRepository;
        }
        public IEnumerable<Core.Domain.Demographic> GetDemographics()
        {
            return _demographicRepository.GetAll();
        }
    }
}
