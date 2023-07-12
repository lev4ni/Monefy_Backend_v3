using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Serilog;

namespace Monefy.DistribuitedWebService.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    public class ExpensesController : Controller
    {
        private readonly IExpenseAppService _expenseAppService;

        public ExpensesController(IExpenseAppService expenseAppService)
        {
            _expenseAppService = expenseAppService;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await _expenseAppService.GetAllExpensesAsync();
            Log.Information("GetAllExpenses: " + expenses.ToList());

            var response = new
            {
                Success = true,
                Message = "Expenses got successfully",
                Data = expenses
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            var expense = await _expenseAppService.GetExpenseByIdAsync(id);

            if (expense == null)
            {
                Log.Error("No hay Expenses!");
                return NotFound();
            }
            Log.Information($"Expense devuelto con éxtito: {expense}");
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

            Log.Information($"Update expense: {expense}");
            await _expenseAppService.UpdateExpenseAsync(expense);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expenseAppService.DeleteExpenseAsync(id);
            Log.Information($"Delete expense {id}");
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
