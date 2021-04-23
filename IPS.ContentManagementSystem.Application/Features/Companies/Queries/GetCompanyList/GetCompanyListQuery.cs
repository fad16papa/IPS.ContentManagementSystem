using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Companies.Queries.GetCompanyList
{
    public class GetCompanyListQuery : IRequest<List<Company>>
    {
    }
}
