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

namespace IPS.ContentManagementSystem.Application.Features.Departments.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Department> _departmentRepository;

        public UpdateDepartmentCommandHandler(IMapper mapper, IAsyncRepository<Department> departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmentToUpdate = await _departmentRepository.GetByIdAsync(request.DepartmentId);

            if (departmentToUpdate == null)
            {
                throw new NotFoundException(nameof(Department), request.DepartmentId);
            }

            departmentToUpdate.Name = request.Name ?? departmentToUpdate.Name;
            departmentToUpdate.Description = request.Description ?? departmentToUpdate.Description;
            departmentToUpdate.IsEnable = request.IsEnable;

            await _departmentRepository.UpdateAsync(departmentToUpdate);

            return Unit.Value;
        }
    }
}
