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
        Task<IEnumerable<EntityCurrency>> GetAllCurrenciesAsync();
        Task<EntityCurrency> GetCurrencyByIdAsync(int guid);
        Task CreateCurrencyAsync(EntityCurrency currency);
        Task UpdateCurrencyAsync(EntityCurrency currency);
        Task DeleteCurrencyAsync(int id);
    }
}
