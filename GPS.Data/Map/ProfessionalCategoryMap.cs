using GPS.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Data.Map
{
    public class ProfessionalCategoryMap
    {
        public ProfessionalCategoryMap(EntityTypeBuilder<ProfessionalCategory> entityBuilder)
        {
            entityBuilder.HasKey(t => t.ProfessionalCategoryId);
            entityBuilder.Property(t => t.Name).IsRequired();
        }
    }
}
