namespace BreadApp.Api.Contracts.BreadDone
{

    public record BreadDoneResponse(Guid Id, string Name, DateTime Date, List<Tuple<string, string>> Ingredients, List<string> Tags);
}