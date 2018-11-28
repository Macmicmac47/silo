using GPS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Core.Domain
{
    public class Address:BaseEntity
    {
        public long AddressId
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public virtual Country Country { get; set; }
        public long? CountryId { get; set; }
    }
}

