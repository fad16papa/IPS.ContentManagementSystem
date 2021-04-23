using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Departments.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest
    {
        public Guid DepartmentId { get; set; }
    }
}
