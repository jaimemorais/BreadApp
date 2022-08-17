using FluentValidation;

namespace BreadApp.Application.Auth.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Password).NotEmpty();
        }
    }

}
