using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Departments.Queries.GetDepartmentList
{
    public class GetDeparmentListQuery : IRequest<List<Department>>
    {
    }
}
