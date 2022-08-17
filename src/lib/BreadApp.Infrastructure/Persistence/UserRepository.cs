using BreadApp.Application.Common.Interfaces.Persistence;
using BreadApp.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BreadApp.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {

        // TODO temporalily in memory
        private static readonly List<User> _userList = new();

        public void Add(User user)
        {
            _userList.Add(user);
        }

        public User GetUserByEmail(string email)
        {
            return _userList.SingleOrDefault(u => u.Email.Equals(email));
        }
    }
}
