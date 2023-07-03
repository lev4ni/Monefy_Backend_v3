using Monefy.Domain.Contracts;
using Monefy.Entities;


namespace Monefy.Domain.Implementation
{
    public class UserBusinessService : IUserBusinessService
    {
        public Task CreateUserAsync(EntityUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EntityUser>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EntityUser> GetUserByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(EntityUser user)
        {
            throw new NotImplementedException();
        }
    }
}
