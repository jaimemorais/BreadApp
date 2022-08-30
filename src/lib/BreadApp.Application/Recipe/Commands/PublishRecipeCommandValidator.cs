using FluentValidation;

namespace BreadApp.Application.Recipe.Commands
{
    public class PublishRecipeCommandValidator : AbstractValidator<PublishRecipeCommand>
    {
        public PublishRecipeCommandValidator()
        {
            RuleFor(r => r.RecipeId).NotEmpty();
            RuleFor(r => r.UserEmail).NotEmpty();
        }
    }
}
