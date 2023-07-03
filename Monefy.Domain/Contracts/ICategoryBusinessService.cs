using Monefy.Entities;


namespace Monefy.Domain.Contracts
{
    public interface ICategoryBusinessService
    {
        Task<IEnumerable<EntityCategory>> GetAllCategoriesAsync();
        Task<EntityCategory> GetCategoryByIdAsync(Guid guid);
        Task CreateCategoryAsync(EntityCategory category);
        Task UpdateCategoryAsync(EntityCategory category);
        Task DeleteCategoryAsync(Guid id);
    }
}
