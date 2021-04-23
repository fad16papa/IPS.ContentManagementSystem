using IPS.ContentManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Persistence.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(d => d.IsEnable)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
