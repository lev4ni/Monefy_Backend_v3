using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.Contracts;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class ExpenseInfraestrucutureService : IExpenseInfraestrucutureService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Expense> _genericRepositoryExpense;
        private readonly IGenericRepository<Wallet> _genericRepositoryWallet;
        private readonly DataBaseContext _dataBaseContext;

        public ExpenseInfraestrucutureService(IMapper mapper, IGenericRepository<Expense> genericRepositoryExpense, IGenericRepository<Wallet> genericRepositoryWallet, DataBaseContext context)
        {
            _mapper = mapper;
            _genericRepositoryExpense = genericRepositoryExpense;
            _genericRepositoryWallet = genericRepositoryWallet;
            _dataBaseContext = context;
        }
        public async Task<IEnumerable<EntityExpense>> GetAllAsync()
        {
            var expenseDataModels = await _genericRepositoryExpense.GetAllAsync( _dataBaseContext);
            return _mapper.Map<IEnumerable<EntityExpense>>(expenseDataModels);
        }

        public async Task<EntityExpense> GetByIdAsync(int id)
        {
            var expensetDataModel = await _genericRepositoryExpense.GetByIdAsync(id, _dataBaseContext);
            return _mapper.Map<EntityExpense>(expensetDataModel);
        }

        public async Task AddAsync(EntityExpense expense)
        {
            var expensetDataModel = _mapper.Map<Expense>(expense);
            await _genericRepositoryExpense.AddAsync(expensetDataModel, _dataBaseContext);
        }

        public async Task UpdateAsync(EntityExpense expense)
        {
            var expensetDataModel = _mapper.Map<Expense>(expense);
            await _genericRepositoryExpense.UpdateAsync(expensetDataModel, _dataBaseContext);
        }

        public async Task DeleteAsync(int id)
        {
            await _genericRepositoryExpense.DeleteAsync(id, _dataBaseContext);
        }

        public async Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId)
        {
            var wallet = await _genericRepositoryWallet.GetByIdAsync(walletId, _dataBaseContext);
            if (wallet != null)
            {
                var walletExpenses = await _dataBaseContext.Expenses
                    .Where(e => e.Wallet.Id == walletId)
                    .ToListAsync();
                return _mapper.Map<IEnumerable<EntityExpense>>(walletExpenses);
            }
            else
            {
                throw new Exception("Wallet does not exist.");
            }
        }
    }
 
}
