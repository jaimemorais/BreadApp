using BreadApp.Domain.Entities;

namespace BreadApp.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);

        void Add(User user);

    }
}
