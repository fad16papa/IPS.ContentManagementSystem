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

namespace IPS.ContentManagementSystem.Application.Features.Companies.Queries.GetCompanyList
{
    public class GetCompanyListQueryHandler : IRequestHandler<GetCompanyListQuery, List<Company>>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Company> _companyRepository;

        public GetCompanyListQueryHandler(IMapper mapper, IAsyncRepository<Company> companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<List<Company>> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
        {
            var allCompanies = (await _companyRepository.ListAllAsync()).OrderBy(x => x.Name);


            return _mapper.Map<List<Company>>(allCompanies);
        }
    }
}
