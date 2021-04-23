using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public Guid PositionId { get; set; }
        public Position Position { get; set; }
        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
