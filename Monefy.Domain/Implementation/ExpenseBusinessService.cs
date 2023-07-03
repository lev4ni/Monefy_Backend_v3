using Monefy.Domain.Contracts;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Domain.Implementation
{
    public class ExpenseBusinessService : IExpenseBusinessService
    {
        public Task CreateExpenseAsync(EntityExpense expense)
        {
            throw new NotImplementedException();
        }

        public Task DeleteExpenseAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EntityExpense>> GetAllExpensesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EntityExpense> GetExpenseByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateExpenseAsync(EntityExpense expense)
        {
            throw new NotImplementedException();
        }
    }
}
