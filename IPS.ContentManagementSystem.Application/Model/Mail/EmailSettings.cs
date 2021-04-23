using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Model.Mail
{
    public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
    }
}
