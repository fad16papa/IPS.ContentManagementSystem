using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest
    {
        public Guid CompanyId { get; set; }
    }
}
