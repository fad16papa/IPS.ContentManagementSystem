using IPS.ContentManagementSystem.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandResponse : BaseResponse
    {
        public CreateDepartmentCommandResponse() : base()
        {
        }

        public CreateDepartmentDto CreateDepartmentDto { get; set; }
    }
}
