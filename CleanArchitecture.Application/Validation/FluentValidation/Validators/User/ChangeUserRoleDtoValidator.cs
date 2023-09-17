using CleanArchitecture.Application.ObjectMapping.AutoMapper.Dtos.User;
using CleanArchitecture.Application.Validation.FluentValidation.Abstract;
using FluentValidation;

namespace CleanArchitecture.Application.Validation.FluentValidation.Validators.User
{
    internal class ChangeUserRoleDtoValidator : BaseValidator<ChangeUserRoleDto>
    {
        public ChangeUserRoleDtoValidator()
        {
            //Rules for Role
            RuleFor(p => p.Role)
                .NotEmpty().WithMessage("{PropertyName} is Required");
        }
    }
}
