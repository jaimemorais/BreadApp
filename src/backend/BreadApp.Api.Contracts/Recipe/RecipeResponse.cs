namespace BreadApp.Api.Contracts.Recipe
{

    public record RecipeResponse(Guid Id, string UserEmail, string Name, DateTime Date, string? Instructions, List<(string IngredientName, string Measure)> Ingredients, List<string> Tags, bool IsPublished);
}