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
        public Task CreateCurrencyAsync(Currency currency)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCurrencyAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Currency>> GetAllCurrenciesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Currency> GetCurrencyByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCurrencyAsync(Currency currency)
        {
            throw new NotImplementedException();
        }
    }
}
