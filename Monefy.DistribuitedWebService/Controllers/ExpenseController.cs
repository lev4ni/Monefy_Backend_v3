using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Application.Implementation;

namespace Monefy.DistribuitedWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : Controller
    {
        /*
        Task<IEnumerable<ExpenseDTO>> GetAllExpensesAsync();
        Task<ExpenseDTO> GetExpenseByIdAsync(Guid id);
        Task CreateExpenseAsync(ExpenseDTO ExpenseDTO);
        Task UpdateExpenseAsync(ExpenseDTO ExpenseDTO);
        Task DeleteExpenseAsync(Guid id);
        */

        private readonly IExpenseAppService _expenseAppService;

        public ExpenseController(IExpenseAppService expenseAppService)
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
        public async Task<IActionResult> GetExpenseById(Guid id)
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
        public async Task<IActionResult> DeleteExpense(Guid id)
        {
            await _expenseAppService.DeleteExpenseAsync(id);
            return Ok();
        }
    }
}
