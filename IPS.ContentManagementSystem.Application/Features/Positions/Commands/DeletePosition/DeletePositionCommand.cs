using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Positions.Commands.DeletePosition
{
    public class DeletePositionCommand : IRequest
    {
        public Guid PositionId { get; set; }
    }
}
