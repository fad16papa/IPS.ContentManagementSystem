using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IPS.ContentManagementSystem.Application.Features.Companies.Queries.GetCompanyDetails
{
    public class GetCompanyDetailsQueryHanlder : IRequestHandler<GetCompanyDetailsQuery, Company>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Company> _companyRepository;

        public GetCompanyDetailsQueryHanlder(IMapper mapper, IAsyncRepository<Company> companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<Company> Handle(GetCompanyDetailsQuery request, CancellationToken cancellationToken)
        {
            var company = await _companyRepository.GetByIdAsync(request.Id);

            return _mapper.Map<Company>(company);
        }
    }
}
