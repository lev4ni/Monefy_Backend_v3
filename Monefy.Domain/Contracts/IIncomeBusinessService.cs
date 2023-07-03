using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Domain.Contracts
{
    public interface IIncomeBusinessService
    {
        Task<IEnumerable<Income>> GetAllIncomesAsync();
        Task<Income> GetIncomeByIdAsync(Guid guid);
        Task CreateIncomeAsync(Income income);
        Task UpdateIncomeAsync(Income income);
        Task DeleteIncomeAsync(Guid id);
    }
}
