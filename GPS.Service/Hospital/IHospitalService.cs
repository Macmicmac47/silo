using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Service.Hospital
{
    public interface IHospitalService
    {
        IEnumerable<GPS.Core.Domain.Hospital> GetHospitals();
        IEnumerable<GPS.Core.Domain.Hospital> GetHospitalbyId(long id);
        void UpdateHospital(GPS.Core.Domain.Hospital hospital);
        void AddHospital(GPS.Core.Domain.Hospital hospital);
        void DeleteHospital(GPS.Core.Domain.Hospital hospital);
    }
}
