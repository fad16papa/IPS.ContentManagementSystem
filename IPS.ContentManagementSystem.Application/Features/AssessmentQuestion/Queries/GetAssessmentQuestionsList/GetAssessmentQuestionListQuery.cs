using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Queries.GetAssessmentQuestionsList
{
    public class GetAssessmentQuestionListQuery : IRequest<List<AssessmentQuestions>>
    {
    }
}
