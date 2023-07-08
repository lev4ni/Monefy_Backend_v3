using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
	public class WalletBusinessService : IWalletBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWalletInfraestrucutureService _walletInfraestrucutureService;
		public WalletBusinessService(IUnitOfWork unitOfWork, IWalletInfraestrucutureService walletInfraestrucutureService)
		{
			_unitOfWork = unitOfWork;
			_walletInfraestrucutureService = walletInfraestrucutureService;
		}
		public async Task<IEnumerable<EntityWallet>> GetAllWalletsAsync()
		{
			var wallet = await _walletInfraestrucutureService.GetAllAsync();
			return wallet;
		}
		public async Task<EntityWallet> GetWalletByIdAsync(int id)
		{
			var wallet = await _walletInfraestrucutureService.GetByIdAsync(id);
			return wallet;
		}
		public async Task CreateWalletAsync(EntityWallet wallet)
		{
			await _walletInfraestrucutureService.AddAsync(wallet);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task UpdateWalletAsync(EntityWallet wallet)
		{
			await _walletInfraestrucutureService.UpdateAsync(wallet);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteWalletAsync(int id)
		{
			await _walletInfraestrucutureService.DeleteAsync(id);
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
