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
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryAppService categoryAppService, ILogger<CategoriesController> logger)
        {
            _categoryAppService = categoryAppService;
            _logger = logger;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllCategories()
        {
            var category = await _categoryAppService.GetAllCategoriesAsync();
            if (category == null)
            {
                _logger.LogWarning("No se han podido obtener todas las categoríasn, no hay.");
                return NotFound();
            }
            _logger.LogInformation("Categiras devueltas: " + category.ToList());
            return Ok(category);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryAppService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                _logger.LogWarning("No se ha podido obtener la categoríasn, no hay.");
                return NotFound();
            }
            _logger.LogInformation("Categiras devuelta: " + category);
            return Ok(category);
        }
        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateCategory(CategoryDTO categoryDTO)
        {
            await _categoryAppService.CreateCategoryAsync(categoryDTO);
            _logger.LogInformation("Categoria creada con éxito!");
            return Ok();
        }

        [HttpDelete]
        [ApiVersion("1.0")]

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryAppService.DeleteCategoryAsync(id);
            _logger.LogInformation("Categoria Borrada con éxito!");
            return Ok();
        }

    }
}
