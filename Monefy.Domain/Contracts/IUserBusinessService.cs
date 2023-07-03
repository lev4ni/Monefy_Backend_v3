using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Domain.Contracts
{
    public interface IUserBusinessService
    {
        Task<IEnumerable<EntityUser>> GetAllUsersAsync();
        Task<EntityUser> GetUserByIdAsync(Guid guid);
        Task CreateUserAsync(EntityUser user);
        Task UpdateUserAsync(EntityUser user);
        Task DeleteUserAsync(Guid id);
    }
}
