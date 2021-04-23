using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPS.ContentManagementSystem.Application.Features.Companies.Commands.CreateCompany;
using IPS.ContentManagementSystem.Application.Features.Companies.Commands.DeleteCompany;
using IPS.ContentManagementSystem.Application.Features.Companies.Commands.UpdateCompany;
using IPS.ContentManagementSystem.Application.Features.Companies.Queries.GetCompanyDetails;
using IPS.ContentManagementSystem.Application.Features.Companies.Queries.GetCompanyList;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPS.ContentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllCompanies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<Company>>> GetAllCompanies()
        {
            var allCompanies = await _mediator.Send(new GetCompanyListQuery());
            return Ok(allCompanies);
        }

        [HttpGet("{id}", Name = "GetCompanyById")]
        public async Task<ActionResult<Company>> GetCompanyById(Guid id)
        {
            var company = new GetCompanyDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(company));
        }

        [HttpPost(Name = "AddCompany")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCompanyCommand createCompanyCommand)
        {
            var company = await _mediator.Send(createCompanyCommand);
            return Ok(company);
        }

        [HttpPut(Name = "UpdateCompany")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateCompanyCommand updateCompanyCommand)
        {
            await _mediator.Send(updateCompanyCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCompany")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteCompanyCommand = new DeleteCompanyCommand() { CompanyId = id };
            await _mediator.Send(deleteCompanyCommand);
            return NoContent();
        }
    }
}
