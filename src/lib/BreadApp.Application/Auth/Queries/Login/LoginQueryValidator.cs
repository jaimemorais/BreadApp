using BreadApp.Application.Auth.Queries.Login;
using FluentValidation;

namespace BreadApp.Application.Auth.Queries.Login
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
