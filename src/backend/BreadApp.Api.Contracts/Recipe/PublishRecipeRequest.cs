namespace BreadApp.Api.Contracts.Recipe
{


    public record PublishRecipeRequest(string UserEmail, Guid RecipeId);
}