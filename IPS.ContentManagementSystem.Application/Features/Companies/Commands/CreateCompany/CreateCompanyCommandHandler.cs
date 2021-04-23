using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using IPS.ContentManagementSystem.Application.Contracts.Persistence;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;

namespace IPS.ContentManagementSystem.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, CreateCompanyCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<Company> _companyRepository;

        public CreateCompanyCommandHandler(IMapper mapper, IAsyncRepository<Company> companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var createCompanyCommandResponse = new CreateCompanyCommandResponse();

            var validator = new CreateCompanyCompanyValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                createCompanyCommandResponse.Success = false;
                createCompanyCommandResponse.ValidationErrors = new List<string>();
                foreach (var item in validationResult.Errors)
                {
                    createCompanyCommandResponse.ValidationErrors.Add(item.ErrorMessage);
                }
            }

            if (createCompanyCommandResponse.Success)
            {
                var company = new Company()
                {
                    Name = request.Name,
                    Description = request.Description,
                    DateCreated = request.DateCreated,
                    IsEnable = request.IsEnable
                };
                company = await _companyRepository.AddAsync(company);
                createCompanyCommandResponse.CreateCompanyDto = _mapper.Map<CreateCompanyDto>(company);
            }

            return createCompanyCommandResponse;
        }
    }
}