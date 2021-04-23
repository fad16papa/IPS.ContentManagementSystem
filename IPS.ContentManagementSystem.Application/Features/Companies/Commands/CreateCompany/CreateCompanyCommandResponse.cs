using IPS.ContentManagementSystem.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandResponse : BaseResponse
    {
        public CreateCompanyCommandResponse() : base()
        {
        }

        public CreateCompanyDto createCompanyDto { get; set; }
    }
}
