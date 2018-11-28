using System;
using System.Collections.Generic;
using System.Text;
using GPS.Core.Domain;
using GPS.Data;

namespace GPS.Service.Hospital
{
    public class HospitalService : IHospitalService
    {
        #region fields
        private readonly IRepository<Core.Domain.Hospital> _hospitalrepository;
        #endregion
        /// <summary>
        /// Get all hospital information
        /// </summary>
        /// <param name="hospitalrepository"></param>
        public HospitalService(IRepository<Core.Domain.Hospital> hospitalrepository)
        {
            this._hospitalrepository = hospitalrepository;
        }

        public void AddHospital(Core.Domain.Hospital hospital)
        {
            _hospitalrepository.Insert(hospital);
        }

        public void DeleteHospital(Core.Domain.Hospital hospital)
        {
            _hospitalrepository.Delete(hospital);
        }

        public IEnumerable<Core.Domain.Hospital> GetHospitalbyId(long id)
        {
            return _hospitalrepository.GetQueryable(id);
        }

        public IEnumerable<Core.Domain.Hospital> GetHospitals()
        {
           return _hospitalrepository.GetAll();
        }

        public void UpdateHospital(Core.Domain.Hospital hospital)
        {
            try
            {
                _hospitalrepository.Update(hospital);
            }
            catch (Exception)
            {

                throw;
            }
             
        }
    }
}
