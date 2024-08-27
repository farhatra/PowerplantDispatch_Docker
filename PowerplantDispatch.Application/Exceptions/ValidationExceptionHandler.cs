using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerplantDispatch.Application.Exceptions
{
    public class ValidationExceptionHandler
    {
        public void Handle(ValidationResult validationResult)
        {
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.Select(e => e.ErrorMessage).ToString());
            }
        }
    }
}
