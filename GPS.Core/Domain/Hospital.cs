using GPS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.Core.Domain
{
   public class Hospital:BaseEntity
    {
        public long HospitalId
        {
            get { return Id; }
            set { Id = value; } 
        }

        public string HospitalName { get; set; }
        public long CountryId { get; set; }
        public string Url { get; set; }
        public string SslEnabled { get; set; }
        public string SecureUrl { get; set; }
        public string Host { get; set; }
        public long DefaultLanguageId { get; set; }
        public long DisplayOrder { get; set; }
        public string HospitalAddress { get; set; }
        public string HospitalPhoneNumber { get; set; }
        public virtual Country Country { get; set; }
    }
    
}
