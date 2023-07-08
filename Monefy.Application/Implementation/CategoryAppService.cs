using AutoMapper;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Application.Implementation
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryBusinessService _categoryBusinessService;
        public CategoryAppService(IMapper mapper, ICategoryBusinessService categoryBusinessService)
        {
            _mapper = mapper;
            _categoryBusinessService = categoryBusinessService;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categoryList = await _categoryBusinessService.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoryList);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryBusinessService.GetCategoryByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }
        public async Task CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            await _categoryBusinessService.CreateCategoryAsync(_mapper.Map<EntityCategory>(categoryDTO));
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryBusinessService.DeleteCategoryAsync(id);
        }


        public async Task UpdateCategoryAsync(CategoryDTO categoryDTO)
        {
            await _categoryBusinessService.UpdateCategoryAsync(_mapper.Map<EntityCategory>(categoryDTO));
        }
    }
}
