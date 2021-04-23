using IPS.ContentManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Persistence.Configurations
{
    public class AssessmentTypeConfiguration : IEntityTypeConfiguration<AssessmentType>
    {
        public void Configure(EntityTypeBuilder<AssessmentType> builder)
        {
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(c => c.IsEnable)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
