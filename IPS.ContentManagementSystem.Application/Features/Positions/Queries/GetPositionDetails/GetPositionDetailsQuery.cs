using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Positions.Queries.GetPositionDetails
{
    public class GetPositionDetailsQuery : IRequest<Position>
    {
        public Guid Id { get; set; }
    }
}
