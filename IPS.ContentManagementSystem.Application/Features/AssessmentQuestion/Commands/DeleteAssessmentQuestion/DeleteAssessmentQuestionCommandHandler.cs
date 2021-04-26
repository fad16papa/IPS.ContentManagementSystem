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

namespace IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Commands.DeleteAssessmentQuestion
{
    public class DeleteAssessmentQuestionCommandHandler : IRequestHandler<DeleteAssessmentQuestionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAssessmentQuestionRepository _assessmentQuestionRepository;

        public DeleteAssessmentQuestionCommandHandler(IMapper mapper, IAssessmentQuestionRepository assessmentQuestionRepository)
        {
            _mapper = mapper;
            _assessmentQuestionRepository = assessmentQuestionRepository;
        }

        public async Task<Unit> Handle(DeleteAssessmentQuestionCommand request, CancellationToken cancellationToken)
        {
            var assessmentQuestionToDelete = await _assessmentQuestionRepository.GetByIdAsync(request.AssessmentQuestionId);

            if (assessmentQuestionToDelete == null)
            {
                throw new NotFoundException(nameof(AssessmentQuestions), request.AssessmentQuestionId);
            }

            await _assessmentQuestionRepository.DeleteAsync(assessmentQuestionToDelete);

            return Unit.Value;
        }
    }
}
