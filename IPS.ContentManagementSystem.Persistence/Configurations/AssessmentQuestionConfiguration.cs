using IPS.ContentManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Persistence.Configurations
{
    public class AssessmentQuestionConfiguration : IEntityTypeConfiguration<AssessmentQuestions>
    {
        public void Configure(EntityTypeBuilder<AssessmentQuestions> builder)
        {
            builder.Property(c => c.Name)
              .IsRequired()
              .HasMaxLength(50);

            builder.Property(c => c.AssessmentTypeId)
                .IsRequired();

            builder.Property(c => c.Points)
              .IsRequired();

            builder.Property(c => c.Question)
                .IsRequired();

            builder.Property(c => c.IsEnable)
                .IsRequired()
                .HasDefaultValue(true);
        }
    }
}
