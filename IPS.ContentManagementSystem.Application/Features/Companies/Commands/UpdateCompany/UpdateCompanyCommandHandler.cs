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

namespace IPS.ContentManagementSystem.Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Company> _companyRepository;

        public UpdateCompanyCommandHandler(IMapper mapper, IAsyncRepository<Company> companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var companyToUpdate = await _companyRepository.GetByIdAsync(request.CompanyId);

            if (companyToUpdate == null)
            {
                throw new NotFoundException(nameof(Department), request.CompanyId);
            }

            companyToUpdate.Name = request.Name ?? companyToUpdate.Name;
            companyToUpdate.Description = request.Description ?? companyToUpdate.Description;
            companyToUpdate.IsEnable = request.IsEnable;

            await _companyRepository.UpdateAsync(companyToUpdate);

            return Unit.Value;
        }
    }
}
