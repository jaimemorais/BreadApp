using BreadApp.Domain.Entities;

namespace BreadApp.Application.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);

        void Add(User user);

    }
}
