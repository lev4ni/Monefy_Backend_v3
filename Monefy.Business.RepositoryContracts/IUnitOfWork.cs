

namespace Monefy.Business.RepositoryContracts
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}
