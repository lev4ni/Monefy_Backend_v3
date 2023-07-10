using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Application.Implementation;
using Monefy.Infraestructure.DataModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monefy.DistribuitedWebService.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [Authorize]
    public class IncomesController : Controller
    {
        private readonly IIncomeAppService _incomeAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IWalletAppService _walletAppService;

        public IncomesController(IIncomeAppService incomeAppService, ICategoryAppService categoryAppService)
        {
            _incomeAppService = incomeAppService;
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeAppService.GetAllIncomesAsync();
            return Ok(incomes);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetIncome(int id)
        {
            var income = await _incomeAppService.GetIncomeByIdAsync(id);

            if (income == null)
            {
                return NotFound();
            }

            return Ok(income);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateIncome(IncomeDTO income)
        {
            // Obtener la categoría original mediante su ID
            var categoryId = income.Id;
            var category = await _categoryAppService.GetCategoryByIdAsync(categoryId);

            if (category != null)
            {
                // Actualizar los valores de la categoría en el objeto Expense
                income.Category.Name = category.Name;
                income.Category.Description = category.Description;
                income.Category.UrlWeb = category.UrlWeb;
            }
            var walletId = income.WalletId;
            var wallet = await _walletAppService.GetWalletByIdAsync(walletId);

            if (wallet != null)
            {
                // Actualizar el walletId en el objeto Expense
                income.WalletId = wallet.Id;
            }
            await _incomeAppService.CreateIncomeAsync(income);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            await _incomeAppService.DeleteIncomeAsync(id);
            return Ok();
        }
    }
}
