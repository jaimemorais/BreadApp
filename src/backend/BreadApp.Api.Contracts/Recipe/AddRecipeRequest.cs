namespace BreadApp.Api.Contracts.Recipe
{


    public record AddRecipeRequest(string UserEmail, string Name, DateTime Date, string? Instructions,
        List<IngredientDto> Ingredients, List<string> Tags);
}