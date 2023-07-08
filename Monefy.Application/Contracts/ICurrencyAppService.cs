using Monefy.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Application.Contracts
{
    public interface ICurrencyAppService
    {
        Task<IEnumerable<CurrencyDTO>> GetAllCurrenciesAsync();
        Task<CurrencyDTO> GetCurrencyByIdAsync(int id);
        Task CreateCurrencyAsync(CurrencyDTO currencyDTO);
        Task UpdateCurrencyAsync(CurrencyDTO currencyDTO);
        Task DeleteCurrencyAsync(int id);
    }
}
