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
        private readonly ICategoryRepository _categoryRepository;


        public WalletBusinessService(IUnitOfWork unitOfWork, IWalletRepository walletRepository,
        IIncomeRepository incomeRepository, IExpenseRepository expenseRepository, IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
			_unitOfWork = unitOfWork;
			_walletRepository = walletRepository;
            _incomeRepository = incomeRepository;
            _expenseRepository = expenseRepository;
			_userRepository = userRepository;
            _categoryRepository = categoryRepository;
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
                var wallets = await _walletRepository.GetUserWalletsAsync(id);
                return wallets;
            }
            else
            {
                throw new Exception("User does not exist.");
            }

        }

        public async Task<IEnumerable<EntityIncome>> GetWalletIncomesAsync(int walletId, DateTime initialDate, DateTime finalDate)
        {
            var wallet = await _walletRepository.GetByIdAsync(walletId);

            if (wallet != null)
            {
                if (wallet.Name == "all")
                {
                    return await _incomeRepository.GetUserIncomesAsync(wallet.User.Id, initialDate, finalDate);
                }
                return await _incomeRepository.GetWalletIncomesAsync(walletId, initialDate, finalDate);
            }
            throw new ArgumentNullException();
        }

        public async Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId, DateTime initialDate, DateTime finalDate)
        {
            var wallet = await _walletRepository.GetByIdAsync(walletId);

            if (wallet != null)
            {
                if (wallet.Name == "all")
                {
                    return await _expenseRepository.GetUserExpensesAsync(wallet.User.Id, initialDate, finalDate);
                }
                return await _expenseRepository.GetWalletExpensesAsync(walletId, initialDate, finalDate);
            }
            throw new ArgumentNullException();

            
        }


        public async Task<IEnumerable<EntityCategoryWithExpenses>> GetCategoriesWithExpenses(int walletId, DateTime initialDate, DateTime finalDate)
        {
            var categoriesWithExpenses = await _categoryRepository.GetCategoriesWithExpenses(walletId, initialDate, finalDate);

            foreach (var categoryWithExpenses in categoriesWithExpenses)
            {
                var totalAmount = 0M;
                foreach (var expense in categoryWithExpenses.Expenses)
                {
                    totalAmount += expense.Amount;
                }

                categoryWithExpenses.TotalAmount = totalAmount;
            }

            return categoriesWithExpenses;
        }
        //iterar sobre cada entity, y de cada entity, iterar sobre los TotalExpenses para cosneguir TotalAmount
         

    }

       
    
}
