using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;
using Monefy.Infraestructure.Repository.Contracts;

namespace Monefy.Domain.Implementation
{
    public class ExpenseBusinessService : IExpenseBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExpenseBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EntityExpense>> GetAllExpensesAsync()
        {
            var expense = await _unitOfWork.ExpenseRepository.GetAllAsync();
            await _unitOfWork.SaveChangesAsync();
            return expense;
        }

        public async Task<EntityExpense> GetExpenseByIdAsync(Guid guid)
        {
            var expenseGuid = await _unitOfWork.ExpenseRepository.GetByIdAsync(guid);
            await _unitOfWork.SaveChangesAsync();
            return expenseGuid;
        }
        public async Task CreateExpenseAsync(EntityExpense expense)
        {
            await _unitOfWork.ExpenseRepository.AddAsync(expense);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateExpenseAsync(EntityExpense expense)
        {
            await _unitOfWork.ExpenseRepository.UpdateAsync(expense);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteExpenseAsync(Guid id)
        {
            await _unitOfWork.ExpenseRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
