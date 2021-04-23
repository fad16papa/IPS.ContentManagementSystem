﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<CreateCompanyCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsEnable { get; set; }
    }
}