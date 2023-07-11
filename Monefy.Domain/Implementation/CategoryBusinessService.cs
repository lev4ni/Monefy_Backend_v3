using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
	public class CategoryBusinessService : ICategoryBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ICategoryRepository _categoryInfraestrucutureService;

		public CategoryBusinessService(IUnitOfWork unitOfWork, ICategoryRepository categoryInfraestrucutureService)
		{
			_unitOfWork = unitOfWork;
			_categoryInfraestrucutureService = categoryInfraestrucutureService;
		}
		public async Task<IEnumerable<EntityCategory>> GetAllCategoriesAsync()
		{
			var category = await _categoryInfraestrucutureService.GetAllAsync();
			return category;
		}
		public async Task<EntityCategory> GetCategoryByIdAsync(int id)
		{
			var categoryGuid = await _categoryInfraestrucutureService.GetByIdAsync(id);
			return categoryGuid;
		}
		public async Task CreateCategoryAsync(EntityCategory category)
		{
			await _categoryInfraestrucutureService.AddAsync(category);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task UpdateCategoryAsync(EntityCategory category)
		{
			await _categoryInfraestrucutureService.UpdateAsync(category);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteCategoryAsync(int id)
		{
			await _categoryInfraestrucutureService.DeleteAsync(id);
			await _unitOfWork.SaveChangesAsync();
		}
	}
}
