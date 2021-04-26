using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Commands.CreateAssessmentType;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Commands.CreateAssessmentQuestion
{
    public class CreateAssessmentQuestionCommandHandler : IRequestHandler<CreateAsssessmentQuestionCommand, CreateAssessmentQuestionCommandReponse>
    {
        private readonly IAsyncRepository<AssessmentQuestions> _assessmentQuestionsRepository;
        private readonly IMapper _mapper;
        public CreateAssessmentQuestionCommandHandler(IMapper mapper, IAsyncRepository<AssessmentQuestions> assessmentQuestionsRepository)
        {
            _mapper = mapper;
            _assessmentQuestionsRepository = assessmentQuestionsRepository;
        }

        public async Task<CreateAssessmentQuestionCommandReponse> Handle(CreateAsssessmentQuestionCommand request, CancellationToken cancellationToken)
        {
            var createAssessmentQuestionsCommandResponse = new CreateAssessmentQuestionCommandReponse();

            var validator = new CreateAssessmentQuestionsCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
            {
                createAssessmentQuestionsCommandResponse.Success = false;
                createAssessmentQuestionsCommandResponse.ValidationErrors = new List<string>();
                foreach (var item in validationResult.Errors)
                {
                    createAssessmentQuestionsCommandResponse.ValidationErrors.Add(item.ErrorMessage);
                }
            }

            if(createAssessmentQuestionsCommandResponse.Success)
            {
                var assessmentQuestion = new AssessmentQuestions()
                {
                    Name = request.Name,
                    Points = request.Points,
                    Question = request.Question,
                    DateCreated = request.DateCreated,
                    IsEnable = request.IsEnable
                };
                assessmentQuestion = await _assessmentQuestionsRepository.AddAsync(assessmentQuestion);
                createAssessmentQuestionsCommandResponse.CreateAssessmentQuestionDto = _mapper.Map<CreateAssessmentQuestionDto>(assessmentQuestion);
            }

            return createAssessmentQuestionsCommandResponse;
        }
    }
}