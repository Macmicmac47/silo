using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Core.Domain
{
    public class CareTeamMemberView
    {
        public long CareTeamMemberId { get; set; }
        public long? AddressId { get; set; }
        public long CountryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Profession { get; set; }
        public string Gender { get; set; }
       public string PlaceofBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public string Demographic { get; set; }
        public string Company { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Specialization { get; set; }
        public long? GenderId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public long? ProfessionalCategoryId { get; set; }
       
        public string PhotoFilePath { get; set; }
    }
}
