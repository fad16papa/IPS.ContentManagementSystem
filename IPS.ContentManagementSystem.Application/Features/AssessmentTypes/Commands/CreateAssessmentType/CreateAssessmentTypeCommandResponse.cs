using IPS.ContentManagementSystem.Application.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Commands.CreateAssessmentType
{
    public class CreateAssessmentTypeCommandResponse : BaseResponse
    {
        public CreateAssessmentTypeCommandResponse() : base()
        {
        }

        public CreateAssessmentTypeDto CreateAssessmentTypeDto { get; set; }
    }
}
