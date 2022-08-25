using FluentValidation;

namespace BreadApp.Application.Recipe.Queries
{

    public class GetRecipeQueryValidator : AbstractValidator<GetRecipeQuery>
    {
        public GetRecipeQueryValidator()
        {
            RuleFor(q => q.Id).NotEmpty();

        }

    }
}