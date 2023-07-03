using Monefy.Domain.Contracts;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Domain.Implementation
{
    public class CurrencyBusinessService : ICurrencyBusinessService
    {
        public Task CreateCurrencyAsync(EntityCurrency currency)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCurrencyAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EntityCurrency>> GetAllCurrenciesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EntityCurrency> GetCurrencyByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCurrencyAsync(EntityCurrency currency)
        {
            throw new NotImplementedException();
        }
    }
}
