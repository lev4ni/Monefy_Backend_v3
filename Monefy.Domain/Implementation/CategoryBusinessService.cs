using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
    public class CategoryBusinessService : ICategoryBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EntityCategory>> GetAllCategoriesAsync()
        {
            var category = await _unitOfWork.CategoryRepository.GetAllAsync();
            await _unitOfWork.SaveChangesAsync();
            return category;
        }
        public async Task<EntityCategory> GetCategoryByIdAsync(Guid guid)
        {
            var categoryGuid = await _unitOfWork.CategoryRepository.GetByIdAsync(guid);
            await _unitOfWork.SaveChangesAsync();
            return categoryGuid;
        }
        public async Task CreateCategoryAsync(EntityCategory category)
        {
            await _unitOfWork.CategoryRepository.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateCategoryAsync(EntityCategory category)
        {
            await _unitOfWork.CategoryRepository.UpdateAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteCategoryAsync(Guid id)
        {
            await _unitOfWork.CategoryRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
