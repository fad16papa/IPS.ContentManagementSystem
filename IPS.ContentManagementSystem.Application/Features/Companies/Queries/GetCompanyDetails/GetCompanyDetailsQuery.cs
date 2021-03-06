using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Companies.Queries.GetCompanyDetails
{
    public class GetCompanyDetailsQuery : IRequest<Company>
    {
        public Guid Id { get; set; }
    }
}
