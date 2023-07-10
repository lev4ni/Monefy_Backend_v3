using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Domain.Implementation
{
	public class WalletBusinessService : IWalletBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWalletInfraestrucutureService _walletInfraestrucutureService;
        private readonly IIncomeInfraestrucutureService _incomeInfraestrucutureService;
        private readonly IExpenseInfraestrucutureService _expenseInfraestrucutureService;

        public WalletBusinessService(IUnitOfWork unitOfWork, IWalletInfraestrucutureService walletInfraestrucutureService,
        IIncomeInfraestrucutureService incomeInfraestrucutureService, IExpenseInfraestrucutureService expenseInfraestrucutureService)
        {
			_unitOfWork = unitOfWork;
			_walletInfraestrucutureService = walletInfraestrucutureService;
            _incomeInfraestrucutureService = incomeInfraestrucutureService;
            _expenseInfraestrucutureService = expenseInfraestrucutureService;
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
		public async Task<IEnumerable<EntityWallet>> GetUsersWalletAsync(int id)
		{
			var usersWallet = await _walletInfraestrucutureService.GetUsersWalletAsync(id);
			return usersWallet;
        }


        public async Task<IEnumerable<EntityIncome>> GetWalletIncomesAsync(int walletId)
        {
            return await _incomeInfraestrucutureService.GetWalletIncomesAsync(walletId);
        }

        public async Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId)
        {
            return await _expenseInfraestrucutureService.GetWalletExpensesAsync(walletId);
        }
    }
}
