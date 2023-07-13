﻿using Monefy.Entities;

namespace Monefy.Business.RepositoryContracts
{
    public interface IExpenseRepository : IGenericRepository<EntityExpense>
    {
        Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId, DateTime initialDate, DateTime finalDate);
        Task<IEnumerable<EntityExpense>> GetExpensesPerMonthAsync(int walletId, DateTime startDate, DateTime endDate);
      
    }
}
