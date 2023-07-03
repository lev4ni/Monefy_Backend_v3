using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;


namespace Monefy.Domain.Implementation
{
    public class WalletBusinessService : IWalletBusinessService
    {
        private IUnitOfWork _unitOfWork;
        public WalletBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EntityWallet>> GetAllWalletsAsync()
        {
            var wallet = await _unitOfWork.WalletRepository.GetAllAsync();
            await _unitOfWork.SaveChangesAsync();
            return wallet;
        }
        public async Task<EntityWallet> GetWalletByIdAsync(Guid guid)
        {
            var wattetGuid = await _unitOfWork.WalletRepository.GetByIdAsync(guid);
            await _unitOfWork.SaveChangesAsync();
            return wattetGuid;
        }
        public async Task CreateWalletAsync(EntityWallet wallet)
        {
            await _unitOfWork.WalletRepository.AddAsync(wallet);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateWalletAsync(EntityWallet wallet)
        {
            await _unitOfWork.WalletRepository.UpdateAsync(wallet);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteWalletAsync(Guid id)
        {
            await _unitOfWork.WalletRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
