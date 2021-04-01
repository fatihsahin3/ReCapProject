using FluentValidation.Results;
using System.Collections.Generic;

namespace Core.Extension
{
    public class ValidationErrorDetails : ErrorDetails 
    {
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }
    }
}
