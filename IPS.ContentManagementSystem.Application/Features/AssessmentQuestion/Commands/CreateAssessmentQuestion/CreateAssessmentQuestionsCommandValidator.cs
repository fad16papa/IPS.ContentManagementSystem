using FluentValidation;

namespace IPS.ContentManagementSystem.Application.Features.AssessmentQuestion.Commands.CreateAssessmentQuestion
{
    public class CreateAssessmentQuestionsCommandValidator : AbstractValidator<CreateAsssessmentQuestionCommand>
    {
        public CreateAssessmentQuestionsCommandValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("{Property is required.}")
               .NotNull()
               .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(x => x.Points)
                .NotNull()
                .WithMessage("Max. number of team members is required")
                .GreaterThan(0)
                .WithMessage("Max. number of team members must be greater than 0");

            RuleFor(x => x.Question)
                .NotEmpty().WithMessage("{Property is required.}")
                .NotNull()
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed 1000 characters");

            RuleFor(x => x.IsEnable)
                .Must(x => x == false || x == true)
                .NotNull();
        }
    }
}