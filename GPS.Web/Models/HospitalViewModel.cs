using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GPS.Web.Models
{
    public class HospitalViewModel
    {
        public long HospitalId { get; set; }
        public string HospitalName { get; set; }
        public long CountryId { get; set; }
        public string CountryName{ get; set; }
        public string CountryfalfPath { get; set; }
        public string Url { get; set; }
        public string SslEnabled { get; set; }
        public string SecureUrl { get; set; }
        public string Host { get; set; }
        public long DefaultLanguageId { get; set; }
        public long DisplayOrder { get; set; }
        public string HospitalAddress { get; set; }
        public string HospitalPhoneNumber { get; set; }
    }
}
