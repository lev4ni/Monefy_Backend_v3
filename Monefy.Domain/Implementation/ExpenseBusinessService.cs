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
            var expenseGuid = await _expenseRepository.GetByIdAsync(id);
            return expenseGuid;
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
        public async Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId)
        {
            return await _expenseRepository.GetWalletExpensesAsync(walletId);
        }

        public async Task<IEnumerable<EntityExpense>> GetExpensesPerMonth(int walletId, DateTime startDate, DateTime endDate)
        {
            return await _expenseRepository.GetExpensesPerMonth(walletId, startDate, endDate);
        }
    }
}
