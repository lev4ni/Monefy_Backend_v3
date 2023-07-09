using Monefy.Application.DTOs;


namespace Monefy.Application.Contracts
{
    public interface IWalletAppService
    {
        Task<IEnumerable<WalletDTO>> GetAllWalletsAsync();
        Task<WalletDTO> GetWalletByIdAsync(int id);
        Task CreateWalletAsync(WalletDTO walletDTO);
        Task UpdateWalletAsync(WalletDTO walletDTO);
        Task DeleteWalletAsync(int id);
        Task<IEnumerable<WalletDTO>> GetUsersWalletAsync(int id);
    }
}
