using Monefy.Entities;


namespace Monefy.Domain.Contracts
{
    public interface ICategoryBusinessService
    {
        Task<IEnumerable<EntityCategory>> GetAllCategoriesAsync();
        Task<EntityCategory> GetCategoryByIdAsync(int guid);
        Task CreateCategoryAsync(EntityCategory category);
        Task UpdateCategoryAsync(EntityCategory category);
        Task DeleteCategoryAsync(int id);
    }
}
