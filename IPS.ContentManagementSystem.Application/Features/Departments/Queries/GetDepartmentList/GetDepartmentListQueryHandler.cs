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

namespace IPS.ContentManagementSystem.Application.Features.Departments.Queries.GetDepartmentList
{
    public class GetDepartmentListQueryHandler : IRequestHandler<GetDeparmentListQuery, List<Department>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Department> _departmentRepository;

        public GetDepartmentListQueryHandler(IMapper mapper, IAsyncRepository<Department> departmentRepository)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
        }

        public async Task<List<Department>> Handle(GetDeparmentListQuery request, CancellationToken cancellationToken)
        {
            var allDepartments = (await _departmentRepository.ListAllAsync()).OrderBy(x => x.Name);

            return _mapper.Map<List<Department>>(allDepartments);
        }
    }
}
