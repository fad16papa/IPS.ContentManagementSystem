using System;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Commands.CreateAssessmentQuestion
{
    public class CreateAsssessmentQuestionCommand : IRequest<CreateAssessmentQuestionCommandReponse>
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Name { get; set; }
        public Guid AssessmentTypeId { get; set; }
        public virtual AssessmentType AssessmentType { get; set; }
        public int Points { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsEnable { get; set; }
    }
}