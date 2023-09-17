using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.Application.Validation.FluentValidation.Abstract;
using FluentValidation;

namespace CleanArchitecture.Application.Validation.FluentValidation.Validators.User
{
    public class CreateUserDtoValidator : BaseValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            //Rules for Name
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is Required")
                .MinimumLength(5).WithMessage("{PropertyName} at least 5 length")
                .MaximumLength(150).WithMessage("{PropertyName} length at max 150");

            //Rules for Email
            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("{PropertyName} is invalid email");

            //Rules for Role
            RuleFor(p => p.Role)
                .NotEmpty().WithMessage("{PropertyName} is Required");
        }
    }
}
