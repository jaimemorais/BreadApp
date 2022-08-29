using FluentValidation;

namespace BreadApp.Application.Recipe.Commands
{
    public class PublishRecipeCommandValidator : AbstractValidator<PublishRecipeCommand>
    {
        public PublishRecipeCommandValidator()
        {
            RuleFor(c => c.UserEmail).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Date).NotEmpty();
        }
    }
}
