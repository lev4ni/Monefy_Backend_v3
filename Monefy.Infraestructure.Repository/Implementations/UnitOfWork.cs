
using Monefy.Business.RepositoryContracts;
using Monefy.Infraestructure.DBContext;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DataBaseContext _categoryContext;
    
        public ICategoryRepository CategoryRepository { get; }
        public ICurrencyRepository CurrencyRepository { get; }
        public IExpenseRepository ExpenseRepository { get; }
        public IUserRepository UserRepository { get; }
        public IWalletRepository WalletRepository { get; }
        public IIncomeRepository IncomeRepository { get; }

        public UnitOfWork(
            DataBaseContext categoryContext, 
       
            ICategoryRepository categoryRepository, 
            ICurrencyRepository currencyRepository,
            IExpenseRepository expenseRepository,
            IUserRepository userRepository,
            IWalletRepository walletRepository,
            IIncomeRepository incomeRepository)
        {
            _categoryContext = categoryContext;
            
            CategoryRepository = categoryRepository;
            CurrencyRepository = currencyRepository;
            ExpenseRepository = expenseRepository;
            UserRepository = userRepository;
            WalletRepository = walletRepository;
            IncomeRepository = incomeRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            await _categoryContext.SaveChangesAsync();
           
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
