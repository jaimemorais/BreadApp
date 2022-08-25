using FluentValidation;

namespace BreadApp.Application.BreadDone.Commands
{
    public class AddBreadDoneCommandValidator : AbstractValidator<AddRecipeCommand>
    {
        public AddBreadDoneCommandValidator()
        {
            RuleFor(c => c.UserEmail).NotEmpty();
            RuleFor(c => c.RecipeId).NotEmpty();
            RuleFor(c => c.Date).NotEmpty();
        }
    }
}
