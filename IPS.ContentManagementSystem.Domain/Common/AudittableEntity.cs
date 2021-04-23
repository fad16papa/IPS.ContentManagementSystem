using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Domain.Common
{
    public class AudittableEntity
    {
        public string CreateBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifyBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
