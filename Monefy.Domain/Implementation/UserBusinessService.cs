using Monefy.Domain.Contracts;
using Monefy.Entities;


namespace Monefy.Domain.Implementation
{
    public class UserBusinessService : IUserBusinessService
    {
        public Task CreateUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
