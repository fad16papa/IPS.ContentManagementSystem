using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Application.Features.Departments.Commands.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, CreateDepartmentCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Department> _departmentRepository;

        public CreateDepartmentCommandHandler(IMapper mapper, IAsyncRepository<Department> departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<CreateDepartmentCommandResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var creatDepartmentCommandResponse = new CreateDepartmentCommandResponse();
                
            var validator = new CreateDepartmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(validationResult.Errors.Count > 0)
            {
                creatDepartmentCommandResponse.Success = false;
                creatDepartmentCommandResponse.ValidationErrors = new List<string>();
                foreach (var item in validationResult.Errors)
                {
                    creatDepartmentCommandResponse.ValidationErrors.Add(item.ErrorMessage);
                }
            }

            if(creatDepartmentCommandResponse.Success)
            {
                var department = new Department()
                {
                    Name = request.Name,
                    Description = request.Description,
                    DateCreated = request.DateCreated,
                    IsEnable = request.IsEnable
                };
                department = await _departmentRepository.AddAsync(department);
                creatDepartmentCommandResponse.CreateDepartmentDto = _mapper.Map<CreateDepartmentDto>(department);
            }

            return creatDepartmentCommandResponse;
        }
    }
}
