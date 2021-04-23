using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Commands.DeleteAssessmentType
{
    public class DeleteAssessmentTypeCommand : IRequest
    {
        public Guid AssessmentTypeId { get; set; }
    }
}
