using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BreadApp.Infrastructure.Persistence.InMemory
{
    public class UserInMemoryRepository : IUserRepository
    {

        private static readonly List<User> _userList = new();

        public void Add(User user)
        {
            _userList.Add(user);
        }

        public User GetUserByEmail(string email)
        {
            return _userList.SingleOrDefault(u => u.Email.Equals(email));
        }

        public User GetUserById(Guid id)
        {
            return _userList.SingleOrDefault(u => u.Id.Equals(id));
        }
    }
}
