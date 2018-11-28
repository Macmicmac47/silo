using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Service.Category
{
     public interface IProfessionalCategory
    {
        IEnumerable<Core.Domain.ProfessionalCategory> GetCategories();
    }
}
