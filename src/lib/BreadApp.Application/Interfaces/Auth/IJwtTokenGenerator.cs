using BreadApp.Domain.Entities;

namespace BreadApp.Application.Interfaces.Auth
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
