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

namespace IPS.ContentManagementSystem.Application.Features.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToDelete = await _companyRepository.GetByIdAsync(request.CompanyId);

            if (companyToDelete == null)
            {
                throw new NotFoundException(nameof(Company), request.CompanyId);
            }

            await _companyRepository.DeleteAsync(companyToDelete);

            return Unit.Value;
        }
    }
}
