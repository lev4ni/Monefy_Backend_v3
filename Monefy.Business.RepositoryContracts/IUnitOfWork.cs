

namespace Monefy.Business.RepositoryContracts
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository CategoryRepository { get;}
        public ICurrencyRepository CurrencyRepository { get; }
        public IExpenseRepository ExpenseRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
