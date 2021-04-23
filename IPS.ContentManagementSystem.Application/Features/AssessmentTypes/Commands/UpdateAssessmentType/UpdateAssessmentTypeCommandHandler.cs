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

namespace IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Commands.UpdateAssessmentType
{
    public class UpdateAssessmentTypeCommandHandler : IRequestHandler<UpdateAssessmentTypeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AssessmentType> _assessmntTypeRepository;

        public UpdateAssessmentTypeCommandHandler(IMapper mapper, IAsyncRepository<AssessmentType> assessmntTypeRepository)
        {
            _mapper = mapper;
            _assessmntTypeRepository = assessmntTypeRepository;
        }

        public async Task<Unit> Handle(UpdateAssessmentTypeCommand request, CancellationToken cancellationToken)
        {
            var assessmentTypeToUpdate = await _assessmntTypeRepository.GetByIdAsync(request.AssessmentTypeId);

            if (assessmentTypeToUpdate == null)
            {
                throw new NotFoundException(nameof(Department), request.AssessmentTypeId);
            }

            assessmentTypeToUpdate.Name = request.Name ?? assessmentTypeToUpdate.Name;
            assessmentTypeToUpdate.Description = request.Description ?? assessmentTypeToUpdate.Description;
            assessmentTypeToUpdate.IsEnable = request.IsEnable;

            await _assessmntTypeRepository.UpdateAsync(assessmentTypeToUpdate);

            return Unit.Value;
        }
    }
}
