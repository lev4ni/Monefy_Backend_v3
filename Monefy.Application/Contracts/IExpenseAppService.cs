using Monefy.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Application.Contracts
{
    public interface IExpenseAppService
    {
        Task<IEnumerable<ExpenseDTO>> GetAllExpensesAsync();
        Task<ExpenseDTO> GetExpenseByIdAsync(Guid id);
        Task CreateExpenseAsync(ExpenseDTO ExpenseDTO);
        Task UpdateExpenseAsync(ExpenseDTO ExpenseDTO);
        Task DeleteExpenseAsync(Guid id);
    }
}
