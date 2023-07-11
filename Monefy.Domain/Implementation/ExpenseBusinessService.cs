using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
	public class ExpenseBusinessService : IExpenseBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IExpenseRepository _expenseRepository;
		public ExpenseBusinessService(IUnitOfWork unitOfWork, IExpenseRepository expenseRepository)
		{
			_unitOfWork = unitOfWork;
			_expenseRepository = expenseRepository;
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
    }
}
