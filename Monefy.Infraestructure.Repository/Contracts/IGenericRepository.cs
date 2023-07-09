

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Monefy.Infraestructure.Repository.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id, DbContext context);
        Task<IEnumerable<TEntity>> GetAllAsync( DbContext context);
        Task AddAsync(TEntity entity, DbContext context);
        Task UpdateAsync(TEntity entity, DbContext context);
        Task DeleteAsync(int id, DbContext context);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, DbContext context);
    }
}
