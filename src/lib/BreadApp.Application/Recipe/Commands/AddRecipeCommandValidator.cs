using FluentValidation;

namespace BreadApp.Application.Recipe.Commands
{
    public class AddRecipeCommandValidator : AbstractValidator<AddRecipeCommand>
    {
        public AddRecipeCommandValidator()
        {
            RuleFor(r => r.UserEmail).NotEmpty();
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Date).NotEmpty();
        }
    }
}
