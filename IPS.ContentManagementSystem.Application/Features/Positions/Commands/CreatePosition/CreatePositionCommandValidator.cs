using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Features.Positions.Commands.CreatePosition
{
    public class CreatePositionCommandValidator : AbstractValidator<CreatePositionCommand>
    {
        public CreatePositionCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("{Property is required.}")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("{Property is required.}")
                .NotNull()
                .MaximumLength(250).WithMessage("{PropertyName} must not exceed 250 characters");

            RuleFor(x => x.IsEnable)
                .Must(x => x == false || x == true)
                .NotNull();
        }   
    }
}
