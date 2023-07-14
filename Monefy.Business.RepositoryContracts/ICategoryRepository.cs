using Microsoft.EntityFrameworkCore;
using Monefy.Entities;


namespace Monefy.Business.RepositoryContracts
{
    public interface ICategoryRepository : IGenericRepository<EntityCategory>
    {
        Task<IEnumerable<EntityCategoryWithExpenses>> GetCategoriesWithExpenses(int walletId, DateTime initialDate, DateTime finalDate);
    }
}
