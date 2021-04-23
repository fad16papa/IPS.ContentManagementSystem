using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPS.ContentManagementSystem.Application.Exceptions
{
    public class ValidationExcepetion : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }
        public ValidationExcepetion(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
