using Microsoft.EntityFrameworkCore;
using Monefy.Entities;


namespace Monefy.Business.RepositoryContracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<EntityCategory>> GetAllAsync();
        Task<EntityCategory> GetByIdAsync(Guid id);
        Task AddAsync(EntityCategory category);
        Task UpdateAsync(EntityCategory category);
        Task DeleteAsync(Guid id);
    }
}
