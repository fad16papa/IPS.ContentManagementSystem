using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Positions.Queries.GetPositionList
{
    public class GetPositionListQuery : IRequest<List<Position>>
    {
    }
}
