

namespace Monefy.Business.RepositoryContracts
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryInfraestrucutureService CategoryRepository { get; }
        public ICurrencyInfraestrucutureService CurrencyRepository { get; }
        public IExpenseInfraestrucutureService ExpenseRepository { get; }
        public IUserInfraestrucutureService UserRepository {get; }
        public IIncomeInfraestrucutureService IncomeRepository { get; }
        public IWalletInfraestrucutureService WalletRepository { get;}
        //public IGenericRepository<TEntity> GenericRepository { get;}

        Task<int> SaveChangesAsync();
    }
}
