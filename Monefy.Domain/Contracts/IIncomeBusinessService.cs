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
        Task<IEnumerable<EntityIncome>> GetAllIncomesAsync();
        Task<EntityIncome> GetIncomeByIdAsync(int guid);
        Task CreateIncomeAsync(EntityIncome income);
        Task UpdateIncomeAsync(EntityIncome income);
        Task DeleteIncomeAsync(int id);
    }
}
