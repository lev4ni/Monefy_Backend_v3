

namespace Monefy.Business.RepositoryContracts
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository CategoryRepository { get; }
        public ICurrencyRepository CurrencyRepository { get; }
        public IExpenseRepository ExpenseRepository { get; }
        public IUserRepository UserRepository {get; }
        public IIncomeRepository IncomeRepository { get; }
        public IWalletRepository WalletRepository { get;}
        //public IGenericRepository<TEntity> GenericRepository { get;}

        Task<int> SaveChangesAsync();
    }
}
