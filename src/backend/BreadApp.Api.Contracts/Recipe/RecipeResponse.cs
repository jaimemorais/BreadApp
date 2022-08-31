namespace BreadApp.Api.Contracts.Recipe
{

    public record RecipeResponse(Guid Id, string UserEmail, string Name, DateTime Date, string? Instructions,
        List<IngredientDto> Ingredients, List<string> Tags, bool IsPublished);
}