

namespace Monefy.Business.RepositoryContracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();

        public void Detach<TEntity>(TEntity entity) where TEntity : class;
    }
}
