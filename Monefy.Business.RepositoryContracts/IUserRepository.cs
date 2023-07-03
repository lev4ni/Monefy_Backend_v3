using Monefy.Entities;

namespace Monefy.Business.RepositoryContracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<EntityUser>> GetAllAsync();
        Task<EntityUser> GetByIdAsync(Guid id);
        Task AddAsync(EntityUser user);
        Task UpdateAsync(EntityUser user);
        Task DeleteAsync(Guid id);
    }
}
