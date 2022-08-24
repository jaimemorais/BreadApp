namespace BreadApp.Api.Contracts.Bread;

public record BreadDoneResponse(Guid Id, DateTime Date, string UserEmail, Guid RecipeId, string Comments, List<string> Tags);

