using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.services;
using ServiceStack;
using System.Collections.Generic;

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
            var expenseDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<EntityExpense>(expenseDataModel);
        }

        public async Task AddAsync(EntityExpense expense)
        {
            var expenseDataModel = _mapper.Map<Expense>(expense);
            _dataBaseContext.Attach(expenseDataModel.Category);
            _dataBaseContext.Attach(expenseDataModel.Wallet);
            await base.AddAsync(expenseDataModel);
        }

        public async Task UpdateAsync(EntityExpense expense)
        {
            var expenseDataModel = _mapper.Map<Expense>(expense);
            await base.UpdateAsync(expenseDataModel);
        }

        public async Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId)
        {
            var wallet = await base.GetByIdAsync(walletId);
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


        public async Task<IEnumerable<EntityExpense>> GetExpensesOfCategoryMonthlyAsync(int walletId, DateTime startDate, DateTime endDate)
        {
            //await base.GetByIdAsync(walletId);
            var expenseDataModel = _mapper.Map<Expense>(walletId);

            _dataBaseContext.Attach(expenseDataModel.Category);
            _dataBaseContext.Attach(expenseDataModel.Wallet);

            var expenses = await _dataBaseContext.Expenses
                .Where(e => e.WalletId == walletId && e.CreatedAt >= startDate && e.CreatedAt <= endDate)
                .Include(e => e.Category)
                .Include(e => e.Wallet)
                //.FirstOrDefaultAsync(e => e.WalletId == walletId)
                .ToListAsync();

            if (expenses == null)
            {
                throw new Exception("No expenses found for the given walletId and dates.");
            }

            return _mapper.Map<IEnumerable<EntityExpense>>(expenses);

            //return _mapper.Map<IEnumerable<EntityExpense>>(expenses);

            //return _mapper.Map<IEnumerable<EntityExpense>>(filteredExpenses);
            //return result;
        }
    }

    
}


