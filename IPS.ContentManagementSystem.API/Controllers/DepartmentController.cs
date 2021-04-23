using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPS.ContentManagementSystem.Application.Features.Departments.Commands.CreateDepartment;
using IPS.ContentManagementSystem.Application.Features.Departments.Commands.DeleteDepartment;
using IPS.ContentManagementSystem.Application.Features.Departments.Commands.UpdateDepartment;
using IPS.ContentManagementSystem.Application.Features.Departments.Queries.GetDeparmentDetails;
using IPS.ContentManagementSystem.Application.Features.Departments.Queries.GetDepartmentList;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPS.ContentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllDepartments")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<Department>>> GetAllDepartments()
        {
            var allDepartments = await _mediator.Send(new GetDeparmentListQuery());
            return Ok(allDepartments);
        }

        [HttpGet("{id}", Name = "GetDepartmentById")]
        public async Task<ActionResult<DepartmentDetailsViewModel>> GetDepartmentById(Guid id)
        {
            var deparment = new GetDepartmentDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(deparment));
        }

        [HttpPost(Name = "AddDepartment")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateDepartmentCommand createDepartmentCommand)
        {
            var department = await _mediator.Send(createDepartmentCommand);
            return Ok(department);
        }

        [HttpPut(Name = "UpdateDepartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateDepartmentCommand updateDepartmentCommand)
        {
            await _mediator.Send(updateDepartmentCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteDepartment")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteDepartmentCommand = new DeleteDepartmentCommand() { DepartmentId = id };
            await _mediator.Send(deleteDepartmentCommand);
            return NoContent();
        }
    }
}
 