using AutoMapper;
using IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Commands.CreateAssessmentType;
using IPS.ContentManagementSystem.Application.Features.Companies.Commands.CreateCompany;
using IPS.ContentManagementSystem.Application.Features.Departments.Commands.CreateDepartment;
using IPS.ContentManagementSystem.Application.Features.Departments.Queries.GetDeparmentDetails;
using IPS.ContentManagementSystem.Application.Features.Positions.Commands.CreatePosition;
using IPS.ContentManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentDetailsViewModel>().ReverseMap();
            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Position, CreatePositionDto>().ReverseMap();
            CreateMap<AssessmentType, CreateAssessmentTypeDto>().ReverseMap();
        }
    }
}
