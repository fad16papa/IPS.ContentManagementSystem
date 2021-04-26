using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Queries.GetAssessmentQuestionsList
{
    public class GetAssessmentQuestionListQueryHandler : IRequestHandler<GetAssessmentQuestionListQuery, List<AssessmentQuestions>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AssessmentQuestions> _assessmentQuestionsRepository;

        public GetAssessmentQuestionListQueryHandler(IMapper mapper, IAsyncRepository<AssessmentQuestions> assessmentQuestionsRepository)
        {
            _mapper = mapper;
            _assessmentQuestionsRepository = assessmentQuestionsRepository;
        }

        public async Task<List<AssessmentQuestions>> Handle(GetAssessmentQuestionListQuery request, CancellationToken cancellationToken)
        {
            var allAssessmentQuestions = (await _assessmentQuestionsRepository.ListAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<List<AssessmentQuestions>>(allAssessmentQuestions);
        }
    }
}
