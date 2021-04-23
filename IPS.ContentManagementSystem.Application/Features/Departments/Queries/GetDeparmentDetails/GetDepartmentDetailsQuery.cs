using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Departments.Queries.GetDeparmentDetails
{
    public class GetDepartmentDetailsQuery : IRequest<DepartmentDetailsViewModel>
    {
        public Guid Id { get; set; }
    }
}
