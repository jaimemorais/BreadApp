using System;

namespace BreadApp.Application.Interfaces.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string userName);
    }
}
