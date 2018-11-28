using GPS.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Data.Map
{
    public class GenderMap
    {
        public GenderMap(EntityTypeBuilder<Gender> entityBuilder)
        {
            entityBuilder.HasKey(t => t.GenderId);
            entityBuilder.Property(t => t.Name).IsRequired();
        }
    }
}
