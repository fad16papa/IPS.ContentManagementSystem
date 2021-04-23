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

namespace IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Commands.DeleteAssessmentType
{
    public class DeleteAssessmentTypeCommandHandler : IRequestHandler<DeleteAssessmentTypeCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAssessmentTypeRepository _assessmentTypeRepository;

        public DeleteAssessmentTypeCommandHandler(IMapper mapper, IAssessmentTypeRepository assessmentTypeRepository)
        {
            _mapper = mapper;
            _assessmentTypeRepository = assessmentTypeRepository;
        }

        public async Task<Unit> Handle(DeleteAssessmentTypeCommand request, CancellationToken cancellationToken)
        {
            var assessmentTypeToDelete = await _assessmentTypeRepository.GetByIdAsync(request.AssessmentTypeId);

            if (assessmentTypeToDelete == null)
            {
                throw new NotFoundException(nameof(AssessmentType), request.AssessmentTypeId);
            }

            await _assessmentTypeRepository.DeleteAsync(assessmentTypeToDelete);

            return Unit.Value;
        }
    }
}
