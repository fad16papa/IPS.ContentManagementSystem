using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Commands.UpdateAssessmentQuestion
{
    public class UpdateAssessmentQuestionCommand : IRequest
    {
        public Guid AssessmentQuestionId { get; set; }
        public string Question { get; set; }
        public string Name { get; set; }
        public Guid AssessmentTypeId { get; set; }
        public virtual AssessmentType AssessmentType { get; set; }
        public int Points { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsEnable { get; set; }
    }
}
