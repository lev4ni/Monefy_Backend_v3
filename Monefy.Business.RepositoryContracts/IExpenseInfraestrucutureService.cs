using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Business.RepositoryContracts
{
    public interface IExpenseInfraestrucutureService
    {
        Task<IEnumerable<EntityExpense>> GetAllAsync();
        Task<EntityExpense> GetByIdAsync(Guid id);
        Task AddAsync(EntityExpense expense);
        Task UpdateAsync(EntityExpense expense);
        Task DeleteAsync(Guid id);
    }
}
