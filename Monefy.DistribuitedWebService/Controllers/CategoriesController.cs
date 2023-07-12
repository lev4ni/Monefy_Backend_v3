using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Serilog;

namespace Monefy.DistribuitedWebService.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    public class CategoriesController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoriesController(ICategoryAppService categoryAppService)
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
                Log.Error("No categories yet.");
                return NotFound();
            }
            var response = new
            {
                Success = true,
                Message = "Categories got successfully",
                Data = category
            };
            Log.Information("Categiries got succesfully: " + category.ToList());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryAppService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                Log.Error("No Category yet.");
                return NotFound();
            }
            var response = new
            {
                Success = true,
                Message = "Category got successfully",
                Data = category
            };
            Log.Information("Categiry got successfully: " + category);
            return Ok(response);
        }
        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateCategory(CategoryDTO categoryDTO)
        {
            var category = await _categoryAppService.CreateCategoryAsync(categoryDTO);
            var response = new
            {
                Success = true,
                Message = "Category created successfully",
                Data = category
            };
            Log.Information("Categor created successfully!");
            return Ok(response);
        }

        [HttpDelete]
        [ApiVersion("1.0")]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryAppService.DeleteCategoryAsync(id);
            var response = new
            {
                Success = true,
                Message = "Category deleted successfully",
                Data = category
            };
            Log.Information("Category deleted successfully");
            return Ok(response);
        }

    }
}
