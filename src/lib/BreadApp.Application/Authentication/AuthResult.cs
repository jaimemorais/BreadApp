using BreadApp.Domain.Entities;

namespace BreadApp.Application.Authentication
{
    public record AuthResult(User User, string Token);


}