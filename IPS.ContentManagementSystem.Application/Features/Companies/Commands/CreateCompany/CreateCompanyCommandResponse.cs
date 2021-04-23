using System;
using System.Collections.Generic;
using System.Text;
using IPS.ContentManagementSystem.Application.Response;

namespace IPS.ContentManagementSystem.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandResponse : BaseResponse
    {
        public CreateCompanyCommandResponse() : base()
        {
        }

        public CreateCompanyDto CreateCompanyDto { get; set; }
    }
}
