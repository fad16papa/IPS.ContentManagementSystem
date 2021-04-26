using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Application.Exceptions;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Commands.UpdateAssessmentQuestion
{
    public class UpdateAssessmentQuestionCommandHandler : IRequestHandler<UpdateAssessmentQuestionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AssessmentQuestions> _asssementQuestionsRepository;

        public UpdateAssessmentQuestionCommandHandler(IMapper mapper, IAsyncRepository<AssessmentQuestions> asssementQuestionsRepository)
        {
            _mapper = mapper;
            _asssementQuestionsRepository = asssementQuestionsRepository;
        }

        public async Task<Unit> Handle(UpdateAssessmentQuestionCommand request, CancellationToken cancellationToken)
        {
            var assessmentQuestionToUpdate = await _asssementQuestionsRepository.GetByIdAsync(request.AssessmentQuestionId);

            if (assessmentQuestionToUpdate == null)
            {
                throw new NotFoundException(nameof(Department), request.AssessmentQuestionId);
            }

            assessmentQuestionToUpdate.Name = request.Name ?? assessmentQuestionToUpdate.Name;
            assessmentQuestionToUpdate.Question = request.Question ?? assessmentQuestionToUpdate.Question;
            assessmentQuestionToUpdate.AssessmentTypeId = request.AssessmentTypeId;
            assessmentQuestionToUpdate.Points = request.Points;
            assessmentQuestionToUpdate.IsEnable = request.IsEnable;

            await _asssementQuestionsRepository.UpdateAsync(assessmentQuestionToUpdate);

            return Unit.Value;
        }
    }
}
