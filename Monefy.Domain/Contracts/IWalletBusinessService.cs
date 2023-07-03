using Monefy.Entities;

namespace Monefy.Domain.Contracts
{
    public interface IWalletBusinessService
    {
        Task<IEnumerable<EntityWallet>> GetAllWalletsAsync();
        Task<EntityWallet> GetWalletByIdAsync(Guid guid);
        Task CreateWalletAsync(EntityWallet wallet);
        Task UpdateWalletAsync(EntityWallet wallet);
        Task DeleteWalletAsync(Guid id);
    }
}
