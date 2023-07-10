using Monefy.Application.DTOs;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Application.Contracts
{
    public interface ICategoryAppService
    {
            Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
            Task<CategoryDTO> GetCategoryByIdAsync(int id);
            Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDTO);
            Task<CategoryDTO> UpdateCategoryAsync(CategoryDTO categoryDTO);
            Task<CategoryDTO> DeleteCategoryAsync(int id);
    
    }
}
