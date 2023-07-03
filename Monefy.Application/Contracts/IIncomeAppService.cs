using Monefy.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Application.Contracts
{
    public interface IIncomeAppService
    {
        Task<IEnumerable<IncomeDTO>> GetAllIncomesAsync();
        Task<IncomeDTO> GetIncomeByIdAsync(Guid id);
        Task CreateIncomeAsync(IncomeDTO incomeDTO);
        Task UpdateIncomeAsync(IncomeDTO incomeDTO);
        Task DeleteIncomeAsync(Guid id);
    }
}
