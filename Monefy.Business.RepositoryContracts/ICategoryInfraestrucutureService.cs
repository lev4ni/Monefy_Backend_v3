using Microsoft.EntityFrameworkCore;
using Monefy.Entities;


namespace Monefy.Business.RepositoryContracts
{
    public interface ICategoryInfraestrucutureService
    {
        Task<IEnumerable<EntityCategory>> GetAllAsync();
        Task<EntityCategory> GetByIdAsync(int id);
        Task AddAsync(EntityCategory category);
        Task UpdateAsync(EntityCategory category);
        Task DeleteAsync(int id);
    }
}
