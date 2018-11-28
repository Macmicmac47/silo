using GPS.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Data.Map
{
   public class HospitalMap
   {
        public HospitalMap(EntityTypeBuilder<Hospital> entityBuilder)
        {
            entityBuilder.HasKey(t => t.HospitalId);
            entityBuilder.Property(t => t.HospitalName).IsRequired();
            entityBuilder.Property(t => t.HospitalPhoneNumber).IsRequired();
            entityBuilder.Property(t => t.HospitalAddress).IsRequired();
            entityBuilder.Property(t => t.Url).IsRequired();
            entityBuilder.Property(t => t.SslEnabled).IsRequired();
            entityBuilder.Property(t => t.Host).IsRequired();
            entityBuilder.Property(t => t.DisplayOrder).IsRequired();
            entityBuilder.Property(t => t.CountryId).IsRequired();
            //entityBuilder.HasOne(e => e.CountryId).WithMany(e => e.Countries).HasForeignKey(e => e.CountryId);


        }
    }
}
