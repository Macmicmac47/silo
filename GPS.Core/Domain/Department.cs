using GPS.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Core.Domain
{
    public class Department:BaseEntity
    {
        public long DepartmentId { get; set; }
        public string Name { get; set; }
    }
}
