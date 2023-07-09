using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;
using Monefy.Infraestructure.Repository.Contracts;

namespace Monefy.Infraestructure.Repository.Implementations
{
        public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
        {
          
            private readonly DbSet<TEntity> _dbSet;

           /* public GenericRepository(DbContext context)
            {
                _context = context;
                _dbSet = _context.Set<TEntity>();
            }*/
            public GenericRepository()
            {

            }

            public async Task<TEntity> GetByIdAsync(Guid id, DbContext context)
            {
                return await context.Set<TEntity>().FindAsync(id);
            }

            public async Task<IEnumerable<TEntity>> GetAllAsync(DbContext context)
            {
                return await context.Set<TEntity>().ToListAsync(); //Where(w => w.UserId == id)
        }

            public async Task AddAsync(TEntity entity, DbContext context)
            {
                await context.Set<TEntity>().AddAsync(entity);
            }

            public async Task UpdateAsync(TEntity entity, DbContext context)
            {
                 context.Set<TEntity>().Update(entity);
                await Task.CompletedTask;
            }

            public async Task DeleteAsync(Guid id, DbContext context)
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

