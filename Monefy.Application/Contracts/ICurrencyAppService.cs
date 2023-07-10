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
        Task<CurrencyDTO> CreateCurrencyAsync(CurrencyDTO currencyDTO);
        Task<CurrencyDTO> UpdateCurrencyAsync(CurrencyDTO currencyDTO);
        Task<CurrencyDTO> DeleteCurrencyAsync(int id);
    }
}
