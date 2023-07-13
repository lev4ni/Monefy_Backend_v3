using Monefy.Application.DTOs;


namespace Monefy.Application.Contracts
{
    public interface IWalletAppService
    {
        Task<IEnumerable<WalletDTO>> GetAllWalletsAsync();
        Task<WalletDTO> GetWalletByIdAsync(int id);
        Task<WalletDTO> CreateWalletAsync(WalletDTO walletDTO);
        Task<WalletDTO> UpdateWalletAsync(WalletDTO walletDTO);
        Task<WalletDTO> DeleteWalletAsync(int id);
        Task<IEnumerable<WalletDTO>> GetUsersWalletAsync(int id);
        Task<IEnumerable<IncomeDTO>> GetWalletIncomesAsync(int walletId, DateTime initialDate, DateTime finalDate);
        Task<IEnumerable<ExpenseDTO>> GetWalletExpensesAsync(int walletId, DateTime initialDate, DateTime finalDate);
    }
}
