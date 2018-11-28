using GPS.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPS.Data.Map
{
    public class CareteamMemberMap
    {
        public CareteamMemberMap(EntityTypeBuilder<CareTeamMember> entityBuilder)
        {
            entityBuilder.HasKey(t => t.CareTeamMemberId);
            entityBuilder.Property(t => t.FirstName).IsRequired();
            entityBuilder.Property(t => t.LastName).IsRequired();
            entityBuilder.Property(t => t.MiddleName).IsRequired();
            entityBuilder.Property(t => t.PhoneNumber).IsRequired();
            entityBuilder.Property(t => t.PhotoFilePath).IsRequired();
            entityBuilder.Property(t => t.Company).IsRequired();
            entityBuilder.Property(t => t.CellNumber).IsRequired();
            entityBuilder.Property(t => t.DateofBirth).IsRequired();
            entityBuilder.Property(t => t.EmailAddress).IsRequired();
            entityBuilder.Property(t => t.Specialization).IsRequired();
            entityBuilder.Property(t => t.TerminationDate).IsRequired();
            entityBuilder.Property(t => t.HireDate).IsRequired();
            entityBuilder.Property(t => t.ProfessionalCategoryId).IsRequired();
            entityBuilder.Property(t => t.GenderId).IsRequired();
            entityBuilder.Property(t => t.AddressId).IsRequired();
            entityBuilder.Property(t => t.PhoneNumber).IsRequired();           


        }
    }
}
