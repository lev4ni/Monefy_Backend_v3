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
            await _expenseAppService.CreateExpenseAsync(expense);
            return Ok();
        }

        [HttpPost("update")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> UpdateExpense(ExpenseDTO expense) 
        { 
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
