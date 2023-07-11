using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.Repository.Implementations;


namespace Monefy.Domain.Implementation
{
	public class WalletBusinessService : IWalletBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWalletRepository _walletRepository;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IUserRepository _userRepository;

        public WalletBusinessService(IUnitOfWork unitOfWork, IWalletRepository walletRepository,
        IIncomeRepository incomeRepository, IExpenseRepository expenseRepository, IUserRepository userRepository)
        {
			_unitOfWork = unitOfWork;
			_walletRepository = walletRepository;
            _incomeRepository = incomeRepository;
            _expenseRepository = expenseRepository;
			_userRepository = userRepository;
        }
		public async Task<IEnumerable<EntityWallet>> GetAllWalletsAsync()
		{
			var wallet = await _walletRepository.GetAllAsync();
			return wallet;
		}
		public async Task<EntityWallet> GetWalletByIdAsync(int id)
		{
			var wallet = await _walletRepository.GetByIdAsync(id);
			return wallet;
		}
		public async Task CreateWalletAsync(EntityWallet wallet)
		{
            var user = await _userRepository.GetByIdAsync(wallet.User.Id);

            if (user == null)
            {
                throw new ArgumentException("Invalid user");
            }

            wallet.User = user;

            await _walletRepository.AddAsync(wallet);
            await _unitOfWork.SaveChangesAsync();
		}
		public async Task UpdateWalletAsync(EntityWallet wallet)
		{
			await _walletRepository.UpdateAsync(wallet);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteWalletAsync(int id)
		{
			await _walletRepository.DeleteAsync(id);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task<IEnumerable<EntityWallet>> GetUsersWalletAsync(int id)
		{

            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                var wallets = await _walletRepository.GetUsersWalletAsync(id);
                return wallets;
            }
            else
            {
                throw new Exception("User does not exist.");
            }

        }


        public async Task<IEnumerable<EntityIncome>> GetWalletIncomesAsync(int walletId)
        {
            return await _incomeRepository.GetWalletIncomesAsync(walletId);
        }

        public async Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId)
        {
            return await _expenseRepository.GetWalletExpensesAsync(walletId);
        }
    }
}
