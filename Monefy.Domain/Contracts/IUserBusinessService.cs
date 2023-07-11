using Monefy.Entities;


namespace Monefy.Domain.Contracts
{
    public interface IUserBusinessService
    {
        Task<IEnumerable<EntityUser>> GetAllUsersAsync();
        Task<EntityUser> GetUserByIdAsync(int guid);
        Task CreateUserAsync(EntityUser user);
        Task UpdateUserAsync(EntityUser user);
        Task DeleteUserAsync(int id);
        Task<EntityUser> ExistsUser(EntityUser entityUser);
        Task<IEnumerable<EntityWallet>> GetUserWallets(int id);
    }
}
