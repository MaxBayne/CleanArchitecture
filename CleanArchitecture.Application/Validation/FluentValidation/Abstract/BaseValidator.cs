using FluentValidation;

namespace CleanArchitecture.Application.Validation.FluentValidation.Abstract
{
    public abstract class BaseValidator<TValidator> :AbstractValidator<TValidator> where TValidator:class
    {
     
    }
}
