using FluentValidation;

namespace BreadApp.Application.Recipe.Commands
{
    public class AddRecipeCommandValidator : AbstractValidator<AddRecipeCommand>
    {
        public AddRecipeCommandValidator()
        {
            RuleFor(c => c.UserEmail).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Date).NotEmpty();
        }
    }
}
