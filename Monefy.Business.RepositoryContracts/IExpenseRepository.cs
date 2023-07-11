using Monefy.Entities;


namespace Monefy.Business.RepositoryContracts
{
    public interface IExpenseRepository : IGenericRepository<EntityExpense>
    {
        Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId);
        Task<IEnumerable<EntityExpense>> GetExpensesPerMonth(int walletId, DateTime startDate, DateTime endDate);
    }
}
