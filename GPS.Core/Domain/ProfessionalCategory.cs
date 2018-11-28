using GPS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Core.Domain
{
    public class ProfessionalCategory:BaseEntity
    {
        public long ProfessionalCategoryId
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Name { get; set; }
    }
}
