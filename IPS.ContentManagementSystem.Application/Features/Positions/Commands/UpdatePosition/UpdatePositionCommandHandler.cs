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

namespace IPS.ContentManagementSystem.Application.Features.Positions.Commands.UpdatePosition
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Position> _positionRepository;

        public UpdatePositionCommandHandler(IMapper mapper, IAsyncRepository<Position> positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public async Task<Unit> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var psotionToUpdate = await _positionRepository.GetByIdAsync(request.PositionId);

            if (psotionToUpdate == null)
            {
                throw new NotFoundException(nameof(Department), request.PositionId);
            }

            psotionToUpdate.Name = request.Name ?? psotionToUpdate.Name;
            psotionToUpdate.Description = request.Description ?? psotionToUpdate.Description;
            psotionToUpdate.IsEnable = request.IsEnable;

            await _positionRepository.UpdateAsync(psotionToUpdate);

            return Unit.Value;
        }
    }
}
