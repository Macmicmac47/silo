using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using GPS.Core.Domain;
using GPS.Data;

namespace GPS.Service.Gender
{
    public class GenderService : IGenderService
    {
        private readonly IRepository<Core.Domain.Gender> _genderrepository;

        public GenderService(IRepository<Core.Domain.Gender> genderrepository)
        {
            this._genderrepository = genderrepository;
        }
        public void AddGender(Core.Domain.Gender gender)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(GetNullableStringParameter("@Name", gender.Name));
            _genderrepository.InsertWithStoredProcedure("usp_AddGender @Name", list.ToArray());
        }
        public SqlParameter GetNullableStringParameter(string parameterName, object value)
        {
            if (value != null)
            {
                return new SqlParameter(parameterName, value);
            }
            else
            {
                return new SqlParameter(parameterName, DBNull.Value);
            }
        }
    }
}
