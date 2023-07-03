using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Business.RepositoryContracts
{
    public interface IIncomeRepository
    {
        Task<IEnumerable<Income>> GetAllAsync();
        Task<Income> GetByIdAsync(Guid id);
        Task AddAsync(Income income);
        Task UpdateAsync(Income income);
        Task DeleteAsync(Guid id);
    }
}
