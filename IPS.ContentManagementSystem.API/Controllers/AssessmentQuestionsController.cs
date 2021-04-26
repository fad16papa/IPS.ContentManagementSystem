using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Commands.CreateAssessmentQuestion;
using IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Commands.DeleteAssessmentQuestion;
using IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Commands.UpdateAssessmentQuestion;
using IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Queries.GetAssessmentQuestionDetails;
using IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Queries.GetAssessmentQuestionsList;
using IPS.ContentManagementSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPS.ContentManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessmentQuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssessmentQuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllAssessmentQuestions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<AssessmentQuestions>>> GetAllAssessmentQuestions()
        {
            var allAassessmentQuestions = await _mediator.Send(new GetAssessmentQuestionListQuery());
            return Ok(allAassessmentQuestions);
        }

        [HttpGet("{id}", Name = "GetAssessmentQuestionsById")]
        public async Task<ActionResult<AssessmentType>> GetAssessmentQuestionsById(Guid id)
        {
            var assessmentQuestions = new GetAssessmentQuestionDetailsQuery() { Id = id };
            return Ok(await _mediator.Send(assessmentQuestions));
        }

        [HttpPost(Name = "AddAssessmentQuestions")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateAsssessmentQuestionCommand createAsssessmentQuestionCommand)
        {
            var assessmentQuestions = await _mediator.Send(createAsssessmentQuestionCommand);
            return Ok(assessmentQuestions);
        }

        [HttpPut(Name = "UpdateAssessmentQuestions")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateAssessmentQuestionCommand updateAssessmentQuestionCommand)
        {
            await _mediator.Send(updateAssessmentQuestionCommand);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteAssessmentQuestion")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteAssessmentQuestionCommand = new DeleteAssessmentQuestionCommand() { AssessmentQuestionId = id };
            await _mediator.Send(deleteAssessmentQuestionCommand);
            return NoContent();
        }
    }
}
