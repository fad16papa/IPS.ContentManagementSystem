using IPS.ContentManagementSystem.Application.Response;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Commands.CreateAssessmentQuestion
{
    public class CreateAssessmentQuestionCommandReponse : BaseResponse
    {
        public CreateAssessmentQuestionCommandReponse() : base()
        {
        }

        public CreateAssessmentQuestionDto CreateAssessmentQuestionDto { get; set; }
    }
}