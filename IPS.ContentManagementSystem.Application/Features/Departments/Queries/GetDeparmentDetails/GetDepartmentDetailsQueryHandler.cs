using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;

namespace IPS.ContentManagementSystem.Application.Features.Departments.Queries.GetDeparmentDetails
{
    public class GetDepartmentDetailsQueryHandler : IRequestHandler<GetDepartmentDetailsQuery, DepartmentDetailsViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Department> _deparmentRepository;

        public GetDepartmentDetailsQueryHandler(IMapper mapper, IAsyncRepository<Department> deparmentRepository)
        {
            _mapper = mapper;
            _deparmentRepository = deparmentRepository;
        }

        public async Task<DepartmentDetailsViewModel> Handle(GetDepartmentDetailsQuery request, CancellationToken cancellationToken)
        {
            var department = await _deparmentRepository.GetByIdAsync(request.Id);

            return _mapper.Map<DepartmentDetailsViewModel>(department);
        }
    }
}
