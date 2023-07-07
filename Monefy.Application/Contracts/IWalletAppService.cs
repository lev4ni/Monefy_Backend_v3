using Monefy.Application.DTOs;


namespace Monefy.Application.Contracts
{
    public interface IWalletAppService
    {
        Task<IEnumerable<WalletDTO>> GetAllWalletsAsync();
        Task<WalletDTO> GetWalletByIdAsync(Guid id);
        Task CreateWalletAsync(WalletDTO walletDTO);
        Task UpdateWalletAsync(WalletDTO walletDTO);
        Task DeleteWalletAsync(Guid id);
    }
}
