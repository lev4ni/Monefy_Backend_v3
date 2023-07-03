using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;

namespace Monefy.DistribuitedWebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
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
        public async Task<IActionResult> CreateCategory(CategoryDTO category)
        {
            await _categoryAppService.CreateCategoryAsync(category);
            return Ok();
        }
    }
}
