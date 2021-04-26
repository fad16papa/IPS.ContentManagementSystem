using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Commands.DeleteAssessmentQuestion
{
    public class DeleteAssessmentQuestionCommand : IRequest
    {
        public Guid AssessmentQuestionId { get; set; }
    }
}
