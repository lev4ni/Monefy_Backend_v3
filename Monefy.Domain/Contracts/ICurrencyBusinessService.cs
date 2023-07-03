using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Domain.Contracts
{
    public interface ICurrencyBusinessService
    {
        Task<IEnumerable<Currency>> GetAllCurrenciesAsync();
        Task<Currency> GetCurrencyByIdAsync(Guid guid);
        Task CreateCurrencyAsync(Currency currency);
        Task UpdateCurrencyAsync(Currency currency);
        Task DeleteCurrencyAsync(Guid id);
    }
}
