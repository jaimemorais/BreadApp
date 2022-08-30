using FluentValidation;

namespace BreadApp.Application.Auth.Queries
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(q => q.Email).NotEmpty();
            RuleFor(q => q.Password).NotEmpty();
        }
    }

}
