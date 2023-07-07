using Monefy.Application.DTOs;


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
