using GPS.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Data.Map
{
    public class DemographicMap
    {
        public DemographicMap(EntityTypeBuilder<Demographic> entityBuilder)
        {
            entityBuilder.HasKey(t => t.DemographicId);
            entityBuilder.Property(t => t.Name).IsRequired();
        }
    }
}

