using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommand : IRequest<CreatePositionCommandResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsEnable { get; set; }
    }
}
