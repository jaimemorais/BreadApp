using System;

namespace BreadApp.Application.Services.Auth
{
    public record AuthResult(Guid Id, string Name, string Email, string Token);


}