using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        public ExpensesController(IExpenseAppService expenseAppService, ICategoryAppService categoryAppService)
        {
            _expenseAppService = expenseAppService;
            _categoryAppService = categoryAppService;
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
            var categoryId = expense.Category.Id;
            var category = await _categoryAppService.GetCategoryByIdAsync(categoryId);

            if (category != null)
            {
                // Asignar el objeto de categoría completo a expense.Category
                expense.Category = category;
            }

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

            //await _expenseAppService.UpdateExpenseAsync(expense);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expenseAppService.DeleteExpenseAsync(id);
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
