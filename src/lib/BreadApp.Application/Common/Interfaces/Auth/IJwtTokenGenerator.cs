using BreadApp.Domain.Entities;

namespace BreadApp.Application.Common.Interfaces.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
