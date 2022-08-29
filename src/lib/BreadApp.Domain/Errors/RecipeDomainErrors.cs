using ErrorOr;

namespace BreadApp.Domain.Errors
{
    public static class RecipeDomainErrors
    {

        public static readonly Error DuplicateName = Error.Validation(code: "Recipe.Duplicated", description: "Recipe name already exists");

        public static readonly Error RecipeNotFound = Error.NotFound(code: "Recipe.RecipeNotFound", description: "Recipe not found with the Id.");


    }
}
