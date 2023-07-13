using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Domain.Implementation
{
    public class ExpenseBusinessService : IExpenseBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExpenseRepository _expenseRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWalletRepository _walletRepository;
        public ExpenseBusinessService(IUnitOfWork unitOfWork, IExpenseRepository expenseRepository, ICategoryRepository categoryRepository, IWalletRepository walletRepository)
        {
            _unitOfWork = unitOfWork;
            _expenseRepository = expenseRepository;
            _categoryRepository = categoryRepository;
            _walletRepository = walletRepository;
        }
        public async Task<IEnumerable<EntityExpense>> GetAllExpensesAsync()
        {
            var expense = await _expenseRepository.GetAllAsync();
            return expense;
        }

        public async Task<EntityExpense> GetExpenseByIdAsync(int id)
        {
            var expense = await _expenseRepository.GetByIdAsync(id);
            return expense;
        }
        public async Task CreateExpenseAsync(EntityExpense expense)
        {
            var category = await _categoryRepository.GetByIdAsync(expense.Category.Id);
            var wallet = await _walletRepository.GetByIdAsync(expense.Wallet.Id);

            if (category == null)
            {
                throw new ArgumentException("Invalid category");
            }

            if (wallet == null)
            {
                throw new ArgumentException("Invalid wallet");
            }

            expense.Category = category;
            expense.Wallet = wallet;
            await _expenseRepository.AddAsync(expense);

            wallet.TotalExpense += expense.Amount;
            wallet.TotalBalance -= expense.Amount;
            await _walletRepository.UpdateAsync(wallet);

            var totalWallet = await _walletRepository.getWalletByUserAndName(wallet.User.Id, "all");
            totalWallet.TotalExpense += expense.Amount;
            totalWallet.TotalBalance -= expense.Amount;
            await _walletRepository.UpdateAsync(totalWallet);



            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateExpenseAsync(EntityExpense expense)
        {
            await _expenseRepository.UpdateAsync(expense);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteExpenseAsync(int id)
        {
            await _expenseRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId, DateTime initialDate, DateTime finalDate)
        {
            return await _expenseRepository.GetWalletExpensesAsync(walletId, initialDate, finalDate);
        }
    }
}
