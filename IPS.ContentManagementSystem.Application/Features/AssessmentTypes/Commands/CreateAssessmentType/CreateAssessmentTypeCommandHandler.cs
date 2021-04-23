using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Commands.CreateAssessmentType
{
    public class CreateAssessmentTypeCommandHandler : IRequestHandler<CreateAssessmentTypeCommand, CreateAssessmentTypeCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AssessmentType> _assessmentTypeRepository;

        public CreateAssessmentTypeCommandHandler(IMapper mapper, IAsyncRepository<AssessmentType> assessmentTypeRepository)
        {
            _mapper = mapper;
            _assessmentTypeRepository = assessmentTypeRepository;
        }

        public async Task<CreateAssessmentTypeCommandResponse> Handle(CreateAssessmentTypeCommand request, CancellationToken cancellationToken)
        {
            var createAssessmentTypeCommandResponse = new CreateAssessmentTypeCommandResponse();

            var valdator = new CreateAssessmentTypeCommandValidator();
            var validationResult = await valdator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
            {
                createAssessmentTypeCommandResponse.Success = false;
                createAssessmentTypeCommandResponse.ValidationErrors = new List<string>();
                foreach (var item in validationResult.Errors)
                {
                    createAssessmentTypeCommandResponse.ValidationErrors.Add(item.ErrorMessage);
                }
            };

            if(createAssessmentTypeCommandResponse.Success)
            {
                var assessmentType = new AssessmentType()
                {
                    Name = request.Name,
                    Description = request.Description,
                    DateCreated = request.DateCreated,
                    IsEnable = request.IsEnable
                };
                assessmentType = await _assessmentTypeRepository.AddAsync(assessmentType);
                createAssessmentTypeCommandResponse.CreateAssessmentTypeDto = _mapper.Map<CreateAssessmentTypeDto>(assessmentType);
            }

            return createAssessmentTypeCommandResponse;
        }
    }
}
