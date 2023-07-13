using Microsoft.AspNetCore.Mvc;
using Monefy.Application.DTOs;
using Monefy.Entities;
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
        Task<ExpenseDTO> GetExpenseByIdAsync(int id);
        Task<ExpenseDTO> CreateExpenseAsync(ExpenseDTO ExpenseDTO);
        Task<ExpenseDTO> UpdateExpenseAsync(ExpenseDTO ExpenseDTO);
        Task<ExpenseDTO> DeleteExpenseAsync(int id);
        Task<IEnumerable<ExpenseDTO>> GetExpensesPerMonthAsync(int walletId, DateTime startDate, DateTime endDate);
    }
}
