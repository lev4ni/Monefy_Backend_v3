using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Domain.Contracts
{
    public interface IExpenseBusinessService
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task<Expense> GetExpenseByIdAsync(Guid guid);
        Task CreateExpenseAsync(Expense expense);
        Task UpdateExpenseAsync(Expense expense);
        Task DeleteExpenseAsync(Guid id);
    }
}
