using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Service.Demographic
{
    public interface IDemographicService
    {
        IEnumerable<Core.Domain.Demographic> GetDemographics();
    }
}
