using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Application.Features.Positions.Queries.GetPositionDetails
{
    public class GetPositionDetailsQueryHandler : IRequestHandler<GetPositionDetailsQuery, Position>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Position> _positionRepository;

        public GetPositionDetailsQueryHandler(IMapper mapper, IAsyncRepository<Position> positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public async Task<Position> Handle(GetPositionDetailsQuery request, CancellationToken cancellationToken)
        {
            var position = await _positionRepository.GetByIdAsync(request.Id);

            return _mapper.Map<Position>(position);
        }
    }
}
