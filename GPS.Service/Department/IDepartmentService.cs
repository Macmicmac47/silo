using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Service.Department
{
   public interface IDepartmentService
    {
        IEnumerable<Core.Domain.Department> GetDsepartments();
    }
}
