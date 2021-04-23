using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Commands.CreateAssessmentType;
using IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Commands.DeleteAssessmentType;
using IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Commands.UpdateAssessmentType;
using IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Queries.GetAssessmentTypeDetails;
using IPS.ContentManagementSystem.Application.Features.AssessmentTypes.Queries.GetAssessmentTypeList;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPS.ContentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssessmentTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllAssessmentTypes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<AssessmentType>>> GetAllAssessmentTypes()
        {
            var allAssessmentTypes = await _mediator.Send(new GetAssessmentTypeListQuery());
            return Ok(allAssessmentTypes);
        }

        [HttpGet("{id}", Name = "GetAssessmentTypeById")]
        public async Task<ActionResult<AssessmentType>> GetAssessmentTypeById(Guid id)
        {
            var assessmentType = new GetAssessmentTypeDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(assessmentType));
        }

        [HttpPost(Name = "AddAssessmentType")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAssessmentTypeCommand createAssessmentTypeCommand)
        {
            var assessmentType = await _mediator.Send(createAssessmentTypeCommand);
            return Ok(assessmentType);
        }

        [HttpPut(Name = "UpdateAssessmentType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateAssessmentTypeCommand updateAssessmentTypeCommand)
        {
            await _mediator.Send(updateAssessmentTypeCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteAssessmentType")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteAssessmentType = new DeleteAssessmentTypeCommand() { AssessmentTypeId = id };
            await _mediator.Send(deleteAssessmentType);
            return NoContent();
        }
    }
}
