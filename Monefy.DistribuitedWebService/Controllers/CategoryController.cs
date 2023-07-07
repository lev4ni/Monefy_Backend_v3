using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;

namespace Monefy.DistribuitedWebService.Controllers
{
    [ApiController]
    [Route("{version:apiVersion}/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllCategories()
        {
            var category = await _categoryAppService.GetAllCategoriesAsync();
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
       
        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var category = await _categoryAppService.GetCategoryByIdAsync(id);
           
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateCategory(CategoryDTO categoryDTO)
        {
            await _categoryAppService.CreateCategoryAsync(categoryDTO);
            return Ok();
        }

        [HttpDelete]
        [ApiVersion("1.0")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _categoryAppService.DeleteCategoryAsync(id);
            return Ok();
        }
        
    }
}
