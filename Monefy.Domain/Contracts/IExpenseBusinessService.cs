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
        Task<IEnumerable<EntityExpense>> GetAllExpensesAsync();
        Task<EntityExpense> GetExpenseByIdAsync(int guid);
        Task CreateExpenseAsync(EntityExpense expense);
        Task UpdateExpenseAsync(EntityExpense expense);
        Task DeleteExpenseAsync(int id);

    }
}
