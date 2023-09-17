using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.Application.Validation.FluentValidation.Abstract;
using FluentValidation;

namespace CleanArchitecture.Application.Validation.FluentValidation.Validators.User
{
    public class DeleteUserDtoValidator:BaseValidator<DeleteUserDto>
    {
        public DeleteUserDtoValidator()
        {
            RuleFor(p => p.UserId)
                .NotNull().WithMessage("{PropertyName} is required")
                .NotEqual(0).WithMessage("{PropertyName} is required");
        }
    }
}
