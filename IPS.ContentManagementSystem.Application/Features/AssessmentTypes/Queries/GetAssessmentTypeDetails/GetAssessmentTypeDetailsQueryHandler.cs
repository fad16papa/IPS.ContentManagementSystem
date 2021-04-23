using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Queries.GetAssessmentTypeDetails
{
    public class GetAssessmentTypeDetailsQueryHandler : IRequestHandler<GetAssessmentTypeDetailsQuery, AssessmentType>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AssessmentType> _assessmentTypeRepository;

        public GetAssessmentTypeDetailsQueryHandler(IMapper mapper, IAsyncRepository<AssessmentType> assessmentTypeRepository)
        {
            _mapper = mapper;
            _assessmentTypeRepository = assessmentTypeRepository;
        }

        public async Task<AssessmentType> Handle(GetAssessmentTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var assessmentType = await _assessmentTypeRepository.GetByIdAsync(request.Id);

            return _mapper.Map<AssessmentType>(assessmentType);
        }
    }
}
