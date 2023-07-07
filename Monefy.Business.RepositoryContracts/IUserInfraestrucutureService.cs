using Microsoft.EntityFrameworkCore;
using Monefy.Entities;

namespace Monefy.Business.RepositoryContracts
{
    public interface IUserInfraestrucutureService
    {
        Task<IEnumerable<EntityUser>> GetAllAsync();
        Task<EntityUser> GetByIdAsync(Guid id);
        Task AddAsync(EntityUser user);
        Task UpdateAsync(EntityUser user);
        Task DeleteAsync(Guid id);
    }
}
