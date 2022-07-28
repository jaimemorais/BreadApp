using BreadApp.Domain.Entities;

namespace BreadApp.Application.Services.Auth
{
    public record AuthResult(User User, string Token);


}