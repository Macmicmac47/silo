using GPS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Core.Domain
{
    public class CareTeamMember:BaseEntity
    {

        public long CareTeamMemberId
        {
            get { return Id; }
            set { Id = value; }
        }
        public long? AddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string PlaceofBirth { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public string Demographic { get; set; }
        public string Company { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public string Specialization { get; set; }
        public long? GenderId { get; set; }
        public List<Address> Address { get; set; }
        public long? ProfessionalCategoryId { get; set; }
        public string PhotoFilePath { get; set; }

    }
}

