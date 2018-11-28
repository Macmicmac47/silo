using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GPS.Web.Models
{
    public class TeamMemberViewModel
    {
        public TeamMemberViewModel()
        {

        }
        public long CareTeamMemberId { get; set; }
        public long? AddressId { get; set; }
        public string Name { get; set; }
        
        public string MiddleName { get; set; }
        [Required]public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required]  public string Gender { get; set; }
        public List<SelectListItem> Genders { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string PlaceofBirth { get; set; }
        [Required]
        public string profession { get; set; }
        public List<SelectListItem> professionList { get; set; }
        [Required]
        public string CellNumber { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public DateTime? DateofBirth { get; set; }
        public string EmergencyContactName { get; set; }
        public string EmergencyContactPhoneNumber { get; set; }
        public string Demographic { get; set; }
        public List<SelectListItem> Demographics { get; set; }
        public string Company { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        [Required]
        public string Specialization { get; set; }
        public List<SelectListItem> Specializations { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }
        
        public string Province { get; set; }
       
        public string PostalCode { get; set; }
        public string PhotoFilePath { get; set; }
        public string Department { get; set; }       
        public List<SelectListItem> DepartmentLists { get; set; }
        public string Country { get; set; }
        public List<SelectListItem> CountryList { get; set; }
    }
}