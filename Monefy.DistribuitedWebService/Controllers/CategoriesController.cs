using Microsoft.AspNetCore.Authorization;
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
                Log.Error("No se han podido obtener todas las categoríasn, no hay.");
                return NotFound();
            }
            Log.Information("Categiras devueltas: " + category.ToList());
            return Ok(category);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryAppService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                Log.Error("No se ha podido obtener la categoríasn, no hay.");
                return NotFound();
            }
            Log.Information("Categiras devuelta: " + category);
            return Ok(category);
        }
        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateCategory(CategoryDTO categoryDTO)
        {
            await _categoryAppService.CreateCategoryAsync(categoryDTO);
            Log.Information("Categoria creada con éxito!");
            return Ok();
        }

        [HttpDelete]
        [ApiVersion("1.0")]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryAppService.DeleteCategoryAsync(id);
            Log.Information("Categoria Borrada con éxito!");
            return Ok();
        }

    }
}
