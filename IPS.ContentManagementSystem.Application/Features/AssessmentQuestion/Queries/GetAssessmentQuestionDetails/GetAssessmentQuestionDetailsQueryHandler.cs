using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Queries.GetAssessmentQuestionDetails
{
    public class GetAssessmentQuestionDetailsQueryHandler : IRequestHandler<GetAssessmentQuestionDetailsQuery, AssessmentQuestions>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AssessmentQuestions> _assessmentQuestionsRepository;

        public GetAssessmentQuestionDetailsQueryHandler(IMapper mapper, IAsyncRepository<AssessmentQuestions> assessmentQuestionsRepository)
        {
            _mapper = mapper;
            _assessmentQuestionsRepository = assessmentQuestionsRepository;
        }

        public async Task<AssessmentQuestions> Handle(GetAssessmentQuestionDetailsQuery request, CancellationToken cancellationToken)
        {
            var assessmentQuestion = await _assessmentQuestionsRepository.GetByIdAsync(request.Id);

            return _mapper.Map<AssessmentQuestions>(assessmentQuestion);
        }
    }
}
