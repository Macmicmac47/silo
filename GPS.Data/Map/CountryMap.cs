using GPS.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Data.Map
{
    public class CountryMap
    {
        public CountryMap(EntityTypeBuilder<Country> entityBuilder)
        {
            entityBuilder.HasKey(t => t.CountryId);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.NumericIsoCode).IsRequired();
            entityBuilder.Property(t => t.ThreeLetterIsoCode).IsRequired();
            entityBuilder.Property(t => t.TwoLetterIsoCode).IsRequired();
        }
    }
}
