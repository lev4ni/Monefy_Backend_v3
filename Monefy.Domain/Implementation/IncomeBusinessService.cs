using Monefy.Domain.Contracts;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Domain.Implementation
{
    public class IncomeBusinessService : IIncomeBusinessService
    {
        public Task CreateIncomeAsync(Income income)
        {
            throw new NotImplementedException();
        }

        public Task DeleteIncomeAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Income>> GetAllIncomesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Income> GetIncomeByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateIncomeAsync(Income income)
        {
            throw new NotImplementedException();
        }
    }
}
