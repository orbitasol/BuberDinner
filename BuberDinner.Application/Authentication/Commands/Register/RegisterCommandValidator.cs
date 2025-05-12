using FluentValidation;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .WithMessage("A valid email address is required.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long.");
    }
}
