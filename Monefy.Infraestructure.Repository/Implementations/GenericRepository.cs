using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;

namespace Monefy.Infraestructure.Repository.Implementations
{
        public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
        {
            private readonly DbContext _context;
            private readonly DbSet<TEntity> _dbSet;

            public GenericRepository(DbContext context)
            {
                _context = context;
                _dbSet = _context.Set<TEntity>();
            }

            public async Task<TEntity> GetByIdAsync(Guid id)
            {
                return await _dbSet.FindAsync(id);
            }

            public async Task<IEnumerable<TEntity>> GetAllAsync()
            {
                return await _dbSet.ToListAsync();
            }

            public async Task AddAsync(TEntity entity)
            {
                await _dbSet.AddAsync(entity);
            }

            public async Task UpdateAsync(TEntity entity)
            {
                _dbSet.Update(entity);
                await Task.CompletedTask;
            }

            public async Task DeleteAsync(Guid id)
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                }
                await Task.CompletedTask;
            }


        }
    }

