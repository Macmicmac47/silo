using GPS.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Data.Map
{
    public class DepartmentMap
    {
        public DepartmentMap(EntityTypeBuilder<Department> entityBuilder)
        {
            entityBuilder.HasKey(t => t.DepartmentId);
            entityBuilder.Property(t => t.Name).IsRequired();
        }
    }
}
