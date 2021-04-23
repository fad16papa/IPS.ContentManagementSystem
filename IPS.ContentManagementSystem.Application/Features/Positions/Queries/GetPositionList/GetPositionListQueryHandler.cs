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

namespace IPS.ContentManagementSystem.Application.Features.Positions.Queries.GetPositionList
{
    public class GetPositionListQueryHandler : IRequestHandler<GetPositionListQuery, List<Position>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Position> _positionRepository;

        public GetPositionListQueryHandler(IMapper mapper, IAsyncRepository<Position> positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public async Task<List<Position>> Handle(GetPositionListQuery request, CancellationToken cancellationToken)
        {
            var allPositions = (await _positionRepository.ListAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<List<Position>>(allPositions);
        }
    }
}
