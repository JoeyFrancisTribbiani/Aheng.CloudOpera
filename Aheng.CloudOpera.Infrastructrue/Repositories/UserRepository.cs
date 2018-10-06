using Aheng.CloudOpera.Core.Entities;
using Aheng.CloudOpera.Core.Interfaces.Repositories;
using Aheng.CloudOpera.Infrastructrue.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aheng.CloudOpera.Infrastructrue.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly OperaContext _operaContext;
        public UserRepository(OperaContext operaContext)
        {
            _operaContext = operaContext;
        }
        public void AddUser(User user)
        {
            _operaContext.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync(string jsonCondition)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsersAsync(IEnumerable<Guid> userIds)
        {
            throw new NotImplementedException();
        }

        public bool TryGetUserByIdAsync(Guid userId, out User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExistAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
