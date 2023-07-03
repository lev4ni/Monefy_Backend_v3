
using Monefy.Business.RepositoryContracts;
using Monefy.Infraestructure.DBContext;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        //private readonly DataBaseContext _dataBaseContext;

        
        private readonly CategoryContext _categoryContext;
        private readonly CurrencyContext _currencyContext;
        private readonly ExpenseContext _expenseContext;
        private readonly UserContext _userContext;
        private readonly WalletContext _walletContext;
        private readonly IncomeContext _incomeContext;

        public ICategoryRepository CategoryRepository { get; }
        public ICurrencyRepository CurrencyRepository { get; }
        public IExpenseRepository ExpenseRepository { get; }
        public IUserRepository UserRepository { get; }
        public IWalletRepository WalletRepository { get; }
        public IIncomeRepository IncomeRepository { get; }


        public UnitOfWork(
            CategoryContext categoryContext, 
            CurrencyContext currencyContext, 
            ExpenseContext expenseContext,
            UserContext userContext,
            WalletContext walletContext,
            IncomeContext incomeContext,

            ICategoryRepository categoryRepository, 
            ICurrencyRepository currencyRepository,
            IExpenseRepository expenseRepository,
            IUserRepository userRepository,
            IWalletRepository walletRepository,
            IIncomeRepository incomeRepository)
        {
            _categoryContext = categoryContext;
            _currencyContext = currencyContext;
            _expenseContext = expenseContext;
            _userContext = userContext;
            _walletContext = walletContext;
            _incomeContext = incomeContext;

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
            await _currencyContext.SaveChangesAsync();
            await _expenseContext.SaveChangesAsync();
            await _userContext.SaveChangesAsync();
            await _walletContext.SaveChangesAsync();
            await _incomeContext.SaveChangesAsync();
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
                    _currencyContext.Dispose();
                    _expenseContext.Dispose();
                    _userContext.Dispose();
                    _walletContext.Dispose();
                    _incomeContext.Dispose();
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
