namespace BreadApp.Api.Contracts.BreadDone
{

    public record BreadDoneResponse(Guid Id, DateTime Date, Guid RecipeId, string RecipeName);
}