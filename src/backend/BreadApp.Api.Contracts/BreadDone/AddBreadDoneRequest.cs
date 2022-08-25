namespace BreadApp.Api.Contracts.BreadDone
{


    public record AddBreadDoneRequest(DateTime Date, string UserEmail, Guid? RecipeId, string? Comments, List<string> Tags);
}