using BreadApp.Domain.Entities;
using System;

namespace BreadApp.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User GetUserByEmail(string email);

        User GetUserById(Guid id);

        void Add(User user);

    }
}
