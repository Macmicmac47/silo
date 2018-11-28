using GPS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Core.Domain
{
    public class Demographic:BaseEntity
    {
        public long DemographicId
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Name { get; set; }
    }
}
