using Monefy.Entities;

namespace Monefy.Domain.Contracts
{
    public interface IWalletBusinessService
    {
        Task<IEnumerable<EntityWallet>> GetAllWalletsAsync();
        Task<EntityWallet> GetWalletByIdAsync(int guid);
        Task CreateWalletAsync(EntityWallet wallet);
        Task UpdateWalletAsync(EntityWallet wallet);
        Task DeleteWalletAsync(int id);
        Task<IEnumerable<EntityWallet>> GetUsersWalletAsync(int id);
        Task<IEnumerable<EntityIncome>> GetWalletIncomesAsync(int walletId);
        Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId);
    }
}
