using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.services;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public ExpenseRepository(IMapper mapper, DataBaseContext context) : base(context)
        {
            _mapper = mapper;
            _dataBaseContext = context;
        }
        public new async Task<IEnumerable<EntityExpense>> GetAllAsync()
        {
            var expenseDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityExpense>>(expenseDataModels);
        }

        public new async Task<EntityExpense> GetByIdAsync(int id)
        {
            var expensetDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<EntityExpense>(expensetDataModel);
        }

        public async Task AddAsync(EntityExpense expense)
        {
            var expenseDataModel = _mapper.Map<Expense>(expense);
            var walletEF = await _dataBaseContext.Wallet.FindAsync(expenseDataModel.Wallet.Id);
            var categoryEF = await _dataBaseContext.Category.FindAsync(expenseDataModel.Category.Id);
            if (walletEF != null && categoryEF != null)
            {
                expenseDataModel.Category = categoryEF;
                expenseDataModel.Wallet = walletEF;
                await base.AddAsync(expenseDataModel);
            }
            else throw new NullReferenceException();
        }

        public async Task UpdateAsync(EntityExpense expense)
        {
            var expensetDataModel = _mapper.Map<Expense>(expense);
            await base.UpdateAsync(expensetDataModel);
        }

        public async Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId, DateTime initialDate, DateTime finalDate)
        {
            var walletExpenses = await _dataBaseContext.Expenses
                    .Where(e => e.Wallet.Id == walletId && e.CreatedAt >= initialDate && e.CreatedAt <= finalDate)
                    .ToListAsync();
            return _mapper.Map<IEnumerable<EntityExpense>>(walletExpenses);
        }

        public async Task<IEnumerable<EntityExpense>> GetUserExpensesAsync(int userId, DateTime initialDate, DateTime finalDate)
        {
            var expenses = await _dataBaseContext.Expenses
                .Where(e => e.Wallet.User.Id == userId && e.CreatedAt >= initialDate && e.CreatedAt <= finalDate)
                .ToListAsync();
            return _mapper.Map<IEnumerable<EntityExpense>>(expenses);
        }
    }
}


