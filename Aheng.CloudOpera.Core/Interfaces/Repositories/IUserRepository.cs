using Aheng.CloudOpera.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aheng.CloudOpera.Core.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid userId);
        bool TryGetUserByIdAsync(Guid userId,out User user);
        Task<IEnumerable<User>> GetUsersAsync(string jsonCondition);
        Task<IEnumerable<User>> GetUsersAsync(IEnumerable<Guid> userIds);
        Task<bool> UserExistAsync(Guid userId);
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
    }
}
