using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using GPS.Core.Domain;
using GPS.Data;

namespace GPS.Service.CareTeam
{
    public class CareTeamService : ICareTeamService
    {
        private readonly IRepository<CareTeamMember> _careteamMemberrepository;

        public CareTeamService(IRepository<CareTeamMember> careteamMemberrepository)
        {
            this._careteamMemberrepository = careteamMemberrepository;
        }

        public IList<CareTeamMemberView> GetTeamMembersInitialInformation(string key, string value)
        {
                       var list = new List<SqlParameter>();
            list.Add(new SqlParameter("@Keywordkey", (object)key));
            list.Add(new SqlParameter("@Keywordvalue", (object)value));
            var query = _careteamMemberrepository.GetListwithStoredProcedure<CareTeamMemberView>("Usp_GetMemberbyKeyword", list);
            return query.ToList();
        }

        public void AddnewTeamMember(CareTeamMemberView member)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(GetNullableStringParameter("@LastName", member.LastName));
            list.Add(GetNullableStringParameter("@FirstName", member.FirstName));
            list.Add(GetNullableStringParameter("@MiddleName", member.MiddleName));
            list.Add(GetNullableStringParameter("@Gender", member.Gender));
            list.Add(GetNullableStringParameter("@Profession", member.ProfessionalCategoryId));
            list.Add(GetNullableStringParameter("@Phone", member.PhoneNumber));
            list.Add(GetNullableStringParameter("@Cell", member.CellNumber));
            list.Add(GetNullableStringParameter("@Email", member.EmailAddress));
            list.Add(GetNullableDateTimeParameter("@dateofBirth", member.DateofBirth));
            list.Add(GetNullableStringParameter("@Company", "compaTest"));
            list.Add(GetNullableStringParameter("@Demographic", member.Demographic));
            list.Add(GetNullableStringParameter("@EmergencyContact", member.EmergencyContactName));
            list.Add(GetNullableStringParameter("@EmergencyPhone", member.EmergencyContactPhoneNumber));
            list.Add(GetNullableDateTimeParameter("@HireDate", member.HireDate));
            list.Add(GetNullableStringParameter("@TerminationDate", DateTime.Now));
            list.Add(GetNullableStringParameter("@Specialization", member.Specialization));
            list.Add(GetNullableStringParameter("@Address1", member.Address1));
            list.Add(GetNullableStringParameter("@Address2", member.Address2));
            list.Add(GetNullableStringParameter("@City", member.City));
            list.Add(GetNullableStringParameter("@Province", member.Province));
            list.Add(GetNullableStringParameter("@PostalCode", member.PostalCode));
            list.Add(GetNullableStringParameter("@Country", member.CountryId));
            list.Add(GetNullableStringParameter("@PhotoFilePath", member.PhotoFilePath));

            _careteamMemberrepository.InsertWithStoredProcedure("[Usp_AddnewTeamMember] @LastName, @FirstName, @MiddleName,@Gender, @Profession, @Phone, @Cell,@Email, @dateofBirth, @Company,@Demographic, @EmergencyContact," +
                "@EmergencyPhone, @HireDate, @TerminationDate, @Specialization, @Address1,@Address2, @City,@Province, @PostalCode, @Country ,@Photofilepath",
                 list.ToArray());
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
        public SqlParameter GetNullableDateTimeParameter(string parameterName, object value)
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
