using Monefy.Application.DTOs;


namespace Monefy.Application.Contracts
{
    public interface IIncomeAppService
    {
        Task<IEnumerable<IncomeDTO>> GetAllIncomesAsync();
        Task<IncomeDTO> GetIncomeByIdAsync(int id);
        Task<IncomeDTO> CreateIncomeAsync(IncomeDTO incomeDTO);
        Task<IncomeDTO> UpdateIncomeAsync(IncomeDTO incomeDTO);
        Task<IncomeDTO> DeleteIncomeAsync(int id);
    }
}
