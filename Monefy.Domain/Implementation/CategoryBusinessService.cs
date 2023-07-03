using Monefy.Domain.Contracts;
using Monefy.Entities;


namespace Monefy.Domain.Implementation
{
    public class CategoryBusinessService : ICategoryBusinessService
    {
        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }
        public Task CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCategoryAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
