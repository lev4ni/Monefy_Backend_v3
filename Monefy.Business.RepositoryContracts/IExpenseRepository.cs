using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Business.RepositoryContracts
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllAsync();
        Task<Expense> GetByIdAsync(Guid id);
        Task AddAsync(Expense expense);
        Task UpdateAsync(Expense expense);
        Task DeleteAsync(Guid id);
    }
}
