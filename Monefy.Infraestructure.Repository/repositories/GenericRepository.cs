using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;
using Monefy.Infraestructure.Repository.Contracts;

namespace Monefy.Infraestructure.Repository.repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        public GenericRepository()
        {
        }

        public async virtual Task<TEntity> GetByIdAsync(int id, DbContext context)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async virtual Task<IEnumerable<TEntity>> GetAllAsync(DbContext context)
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async virtual Task AddAsync(TEntity entity, DbContext context)
        {
            await context.Set<TEntity>().AddAsync(entity);
        }

        public async virtual Task UpdateAsync(TEntity entity, DbContext context)
        {
            context.Set<TEntity>().Update(entity);
            await Task.CompletedTask;
        }

        public async virtual Task DeleteAsync(int id, DbContext context)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                context.Set<TEntity>().Remove(entity);
            }
            await Task.CompletedTask;
        }


    }
}

