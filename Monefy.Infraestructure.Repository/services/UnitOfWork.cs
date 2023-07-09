
using Monefy.Business.RepositoryContracts;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.Contracts;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataBaseContext _categoryContext;

        public UnitOfWork(DataBaseContext categoryContext)
        {
            _categoryContext = categoryContext;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _categoryContext.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _categoryContext.Dispose();
                    
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }


}
