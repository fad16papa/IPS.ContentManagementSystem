using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Domain.Entities
{
    public class AppUserRole : IdentityRole
    {
        public DateTime DateCreated { get; set; }
        public bool IsEnable { get; set; }
    }
}
