using API.Api.Requests;
using FluentValidation;

namespace API.Validators.Users;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name cannot be null or empty");
        RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Password cannot be null or empty");
        RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Email cannot be null or empty");
        RuleFor(x => x.Email).EmailAddress().WithMessage("Email is invalid");
    }
}