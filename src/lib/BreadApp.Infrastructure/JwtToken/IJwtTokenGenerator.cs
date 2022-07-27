using System;

namespace BreadApp.Infrastructure.JwtToken
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string userName);
    }
}
