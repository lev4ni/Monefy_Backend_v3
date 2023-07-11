using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
	public class CategoryBusinessService : ICategoryBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICategoryRepository _categoryRepository;

		public CategoryBusinessService(IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
		{
			_unitOfWork = unitOfWork;
            _categoryRepository = categoryRepository;
		}
		public async Task<IEnumerable<EntityCategory>> GetAllCategoriesAsync()
		{
			var category = await _categoryRepository.GetAllAsync();
			return category;
		}
		public async Task<EntityCategory> GetCategoryByIdAsync(int id)
		{
			var categoryGuid = await _categoryRepository.GetByIdAsync(id);
			return categoryGuid;
		}
		public async Task CreateCategoryAsync(EntityCategory category)
		{
			await _categoryRepository.AddAsync(category);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task UpdateCategoryAsync(EntityCategory category)
		{
			await _categoryRepository.UpdateAsync(category);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteCategoryAsync(int id)
		{
			await _categoryRepository.DeleteAsync(id);
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
