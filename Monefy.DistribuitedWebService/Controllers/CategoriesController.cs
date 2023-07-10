﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Infraestructure.DataModels;

namespace Monefy.DistribuitedWebService.Controllers
{
    [ApiController]
    [Route("{version:apiVersion}/[controller]")]
    [Authorize]
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
                return NotFound();
            }
            return Ok(category);
        }
       
        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetCategoryById(int id)
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

        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryAppService.DeleteCategoryAsync(id);
            return Ok();
        }
        
    }
}
