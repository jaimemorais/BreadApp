namespace BreadApp.Api.Contracts.Auth;

public record AuthResponse(Guid Id, string Name, string Email, string Token);

