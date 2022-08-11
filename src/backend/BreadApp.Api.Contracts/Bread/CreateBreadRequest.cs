namespace BreadApp.Api.Contracts.Bread;

public record CreateBreadRequest(
    string Name,
    string Description,
    List<string> Tags);