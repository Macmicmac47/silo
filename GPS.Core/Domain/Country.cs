using GPS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Core.Domain
{
    public class Country:BaseEntity
    {
        public long CountryId
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Name { get; set; }
        public string TwoLetterIsoCode { get; set; }
        public string ThreeLetterIsoCode { get; set; }
        public string NumericIsoCode { get; set; }
       
    }
}
