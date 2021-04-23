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

namespace IPS.ContentManagementSystem.Application.Features.Positions.Commands.DeletePosition
{
    public class DeletePositionCommandHandler : IRequestHandler<DeletePositionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IPositionRepository _positionRepository;

        public DeletePositionCommandHandler(IMapper mapper, IPositionRepository positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public async Task<Unit> Handle(DeletePositionCommand request, CancellationToken cancellationToken)
        {
            var positionToDelete = await _positionRepository.GetByIdAsync(request.PositionId);

            if (positionToDelete == null)
            {
                throw new NotFoundException(nameof(Position), request.PositionId);
            }

            await _positionRepository.DeleteAsync(positionToDelete);

            return Unit.Value;
        }
    }
}
