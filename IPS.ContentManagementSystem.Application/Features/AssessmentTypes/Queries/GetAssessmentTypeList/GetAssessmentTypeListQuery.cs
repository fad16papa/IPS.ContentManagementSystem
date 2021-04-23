using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Queries.GetAssessmentTypeList
{
    public class GetAssessmentTypeListQuery : IRequest<List<AssessmentType>>
    {
    }
}
