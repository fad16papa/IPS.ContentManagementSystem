using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Queries.GetAssessmentTypeList
{
    public class GetAssessmentTypeListQueryHandler : IRequestHandler<GetAssessmentTypeListQuery, List<AssessmentType>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<AssessmentType> _assessmentTypeRepository;

        public GetAssessmentTypeListQueryHandler(IMapper mapper, IAsyncRepository<AssessmentType> assessmentTypeRepository)
        {
            _mapper = mapper;
            _assessmentTypeRepository = assessmentTypeRepository;
        }

        public async Task<List<AssessmentType>> Handle(GetAssessmentTypeListQuery request, CancellationToken cancellationToken)
        {
            var allAssessmentType = (await _assessmentTypeRepository.ListAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<List<AssessmentType>>(allAssessmentType);
        }
    }
}
