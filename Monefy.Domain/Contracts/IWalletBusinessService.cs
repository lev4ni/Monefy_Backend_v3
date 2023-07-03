using Monefy.Entities;

namespace Monefy.Domain.Contracts
{
    public interface IWalletBusinessService
    {
        Task<IEnumerable<Wallet>> GetAllWalletsAsync();
        Task<Wallet> GetWalletByIdAsync(Guid guid);
        Task CreateWalletAsync(Wallet wallet);
        Task UpdateWalletAsync(Wallet wallet);
        Task DeleteWalletAsync(Guid id);
    }
}
