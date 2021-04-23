using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, CreatePositionCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Position> _positionRepository;

        public CreatePositionCommandHandler(IMapper mapper, IAsyncRepository<Position> positionRepository)
        {
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public async Task<CreatePositionCommandResponse> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var createPositionCommandResponse = new CreatePositionCommandResponse();

            var validator = new CreatePositionCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
            {
                createPositionCommandResponse.Success = false;
                createPositionCommandResponse.ValidationErrors = new List<string>();
                foreach (var item in validationResult.Errors)
                {
                    createPositionCommandResponse.ValidationErrors.Add(item.ErrorMessage);
                }
            }

            if(createPositionCommandResponse.Success)
            {
                var positions = new Position()
                {
                    Name = request.Name,
                    Description = request.Description,
                    DateCreated = request.DateCreated,
                    IsEnable = request.IsEnable
                };
                positions = await _positionRepository.AddAsync(positions);
                createPositionCommandResponse.CreatePositionDto = _mapper.Map<CreatePositionDto>(positions);
            }

            return createPositionCommandResponse;
        }
    }
}
