using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPS.ContentManagementSystem.Application.Features.Positions.Commands.CreatePosition;
using IPS.ContentManagementSystem.Application.Features.Positions.Commands.DeletePosition;
using IPS.ContentManagementSystem.Application.Features.Positions.Commands.UpdatePosition;
using IPS.ContentManagementSystem.Application.Features.Positions.Queries.GetPositionDetails;
using IPS.ContentManagementSystem.Application.Features.Positions.Queries.GetPositionList;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPS.ContentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PositionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllPositions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<Position>>> GetAllPositions()
        {
            var allPositions = await _mediator.Send(new GetPositionListQuery());
            return Ok(allPositions);
        }

        [HttpGet("{id}", Name = "GetPositionById")]
        public async Task<ActionResult<Company>> GetPositionById(Guid id)
        {
            var position = new GetPositionDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(position));
        }

        [HttpPost(Name = "AddPosition")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePositionCommand createPositionCommand)
        {
            var position = await _mediator.Send(createPositionCommand);
            return Ok(position);
        }

        [HttpPut(Name = "UpdatePosition")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdatePositionCommand updatePositionCommand)
        {
            await _mediator.Send(updatePositionCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeletePosition")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deletePositionCommand = new DeletePositionCommand() { PositionId = id };
            await _mediator.Send(deletePositionCommand);
            return NoContent();
        }
    }
}
