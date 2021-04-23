using IPS.ContentManagementSystem.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandResponse : BaseResponse
    {
        public CreatePositionCommandResponse() : base()
        {
        }

        public CreatePositionDto CreatePositionDto { get; set; }
    }
}
