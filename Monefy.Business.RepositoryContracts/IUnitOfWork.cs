

using Monefy.Business.RepositoryContracts;

namespace Monefy.Business.RepositoryContracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}
