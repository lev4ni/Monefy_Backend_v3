using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Application.Implementation;
using Monefy.Infraestructure.DataModels;


namespace Monefy.DistribuitedWebService.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    public class ExpensesController : Controller
    {
        private readonly IExpenseAppService _expenseAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly ILogger<ExpensesController> _logger;

        public ExpensesController(IExpenseAppService expenseAppService, ICategoryAppService categoryAppService, ILogger<ExpensesController> logger)
        {
            _expenseAppService = expenseAppService;
            _categoryAppService = categoryAppService;
            _logger = logger;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expense = await _expenseAppService.GetAllExpensesAsync();
            _logger.LogInformation("GetAllExpenses: " + expense.ToList());
            return Ok(expense);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            var expense = await _expenseAppService.GetExpenseByIdAsync(id);

            if (expense == null)
            {
                _logger.LogError("No hay Expenses!");
                return NotFound();
            }
            _logger.LogInformation($"Expense devuelto con éxtito: {expense}");
            return Ok(expense);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateExpense(ExpenseDTO expense)
        {
            await _expenseAppService.CreateExpenseAsync(expense);
            return Ok(expense);
        }

        [HttpPut("update")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> UpdateExpense(ExpenseDTO expense)
        {
            //var categoryId = expense.Category.Id;
            //var category = await _categoryAppService.GetCategoryByIdAsync(categoryId);
            //if (category != null)
            //{
            //    expense.Category.Name = category.Name;
            //    expense.Category.Description = category.Description;
            //    expense.Category.UrlWeb = category.UrlWeb;
            //}

            _logger.LogInformation($"Update expense: {expense}");
            await _expenseAppService.UpdateExpenseAsync(expense);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expenseAppService.DeleteExpenseAsync(id);
            _logger.LogInformation($"Delete expense {id}");
            return Ok();
        }

        [HttpGet("{walletId}")]
        public async Task<IEnumerable<IActionResult>> GetExpensesMonthly(int walletId, DateTime startDate, DateTime endDate)
        {
            await _expenseAppService.GetExpensesPerMonthAsync(walletId, startDate, endDate);
            return (IEnumerable<IActionResult>)Ok();
        }
    }
}
