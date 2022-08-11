namespace BreadApp.Api.Contracts.Bread;

public record BreadResponse(Guid Id, string Name, string Description, List<string> Tags);

