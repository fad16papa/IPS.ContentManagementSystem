using IPS.ContentManagementSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Persistence
{
    public class IPSContentManagementDbContext : IdentityDbContext<AppUser, AppUserRole, string>
    {
        public IPSContentManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<AssessmentType> AssessmentTypes { get; set; }
        public DbSet<AssessmentQuestions> AssessmentQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
                .HasOne<Position>(p => p.Position)
                .WithMany(a => a.AppUser)
                .HasForeignKey(p => p.PositionId);

            builder.Entity<AppUser>()
                .HasOne<Department>(d => d.Department)
                .WithMany(a => a.AppUser)
                .HasForeignKey(d => d.DepartmentId);

            builder.Entity<AppUser>()
                .HasOne<Company>(c => c.Company)
                .WithMany(a => a.AppUser)
                .HasForeignKey(c => c.CompanyId);

            builder.Entity<AssessmentQuestions>()
                .HasOne<AssessmentType>(at => at.AssessmentType)
                .WithMany(aq => aq.AssessmentQuestions)
                .HasForeignKey(at => at.AssessmentTypeId);
        }
    }
}
