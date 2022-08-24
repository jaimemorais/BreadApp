namespace BreadApp.Api.Contracts.Bread;

public record AddBreadDoneRequest(DateTime Date, string UserEmail, Guid? RecipeId, string? Comments, List<string> Tags);