using Monefy.Domain.Contracts;
using Monefy.Entities;


namespace Monefy.Domain.Implementation
{
    public class CategoryBusinessService : ICategoryBusinessService
    {
        public Task<IEnumerable<EntityCategory>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }
        public Task CreateCategoryAsync(EntityCategory category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EntityCategory> GetCategoryByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(EntityCategory category)
        {
            throw new NotImplementedException();
        }
    }
}
