using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Application.Implementation;

namespace Monefy.DistribuitedWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpensesController : Controller
    {
        private readonly IExpenseAppService _expenseAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IWalletAppService _walletAppService;

        public ExpensesController(IExpenseAppService expenseAppService, ICategoryAppService categoryAppService, IWalletAppService walletAppService)
        {
            _expenseAppService = expenseAppService;
            _categoryAppService = categoryAppService;
            _walletAppService = walletAppService;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllExpenses()
        {
            var incomes = await _expenseAppService.GetAllExpensesAsync();
            return Ok(incomes);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            var income = await _expenseAppService.GetExpenseByIdAsync(id);

            if (income == null)
            {
                return NotFound();
            }

            return Ok(income);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateExpense(ExpenseDTO expense)
        {
            // Obtener la categoría original mediante su ID
            var categoryId = expense.Category.Id;
            var category = await _categoryAppService.GetCategoryByIdAsync(categoryId);

            if (category != null)
            {
                // Actualizar los valores de la categoría en el objeto Expense
                expense.Category.Name = category.Name;
                expense.Category.Description = category.Description;
                expense.Category.UrlWeb = category.UrlWeb;
            }
            // Obtener el wallet original mediante su ID
            var walletId = expense.WalletId;
            var wallet = await _walletAppService.GetWalletByIdAsync(walletId);

            if (wallet != null)
            {
                // Actualizar el walletId en el objeto Expense
                expense.WalletId = wallet.Id;
            }

            await _expenseAppService.CreateExpenseAsync(expense);
            return Ok(expense);
        }

        [HttpPut("update")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> UpdateExpense(ExpenseDTO expense) 
        {
            var categoryId = expense.Category.Id;
            var category = await _categoryAppService.GetCategoryByIdAsync(categoryId);

            if (category != null)
            {
                expense.Category.Name = category.Name;
                expense.Category.Description = category.Description;
                expense.Category.UrlWeb = category.UrlWeb;
            }

            await _expenseAppService.UpdateExpenseAsync(expense);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expenseAppService.DeleteExpenseAsync(id);
            return Ok();
        }
    }
}
