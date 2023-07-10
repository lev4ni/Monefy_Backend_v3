using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
	public class ExpenseBusinessService : IExpenseBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IExpenseInfraestrucutureService _expenseInfraestrucutureService;
		public ExpenseBusinessService(IUnitOfWork unitOfWork, IExpenseInfraestrucutureService expenseInfraestrucutureService)
		{
			_unitOfWork = unitOfWork;
			_expenseInfraestrucutureService = expenseInfraestrucutureService;
		}
		public async Task<IEnumerable<EntityExpense>> GetAllExpensesAsync()
		{
			var expense = await _expenseInfraestrucutureService.GetAllAsync();
			return expense;
		}

		public async Task<EntityExpense> GetExpenseByIdAsync(int id)
		{
			var expenseGuid = await _expenseInfraestrucutureService.GetByIdAsync(id);
			return expenseGuid;
		}
		public async Task CreateExpenseAsync(EntityExpense expense)
		{
			await _expenseInfraestrucutureService.AddAsync(expense);
			await _unitOfWork.SaveChangesAsync();
		}

		public async Task UpdateExpenseAsync(EntityExpense expense)
		{
			await _expenseInfraestrucutureService.UpdateAsync(expense);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteExpenseAsync(int id)
		{
			await _expenseInfraestrucutureService.DeleteAsync(id);
			await _unitOfWork.SaveChangesAsync();
		}
        public async Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId)
        {
            return await _expenseInfraestrucutureService.GetWalletExpensesAsync(walletId);
        }
    }
}
