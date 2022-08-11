using BreadApp.Domain.Entities;

namespace BreadApp.Application.Auth
{
    public record AuthResult(User User, string Token);


}