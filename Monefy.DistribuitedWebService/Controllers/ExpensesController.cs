using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
<<<<<<< HEAD
using Monefy.Application.Implementation;
using Monefy.Infraestructure.DataModels;
=======

>>>>>>> master

namespace Monefy.DistribuitedWebService.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    public class ExpensesController : Controller
    {
        private readonly IExpenseAppService _expenseAppService;
        private readonly ICategoryAppService _categoryAppService;
<<<<<<< HEAD

        public ExpensesController(IExpenseAppService expenseAppService, ICategoryAppService categoryAppService)
        {
            _expenseAppService = expenseAppService;
            _categoryAppService = categoryAppService;
=======
        private readonly IWalletAppService _walletAppService;
        private readonly ILogger<ExpensesController> _logger;

        public ExpensesController(IExpenseAppService expenseAppService, ICategoryAppService categoryAppService, IWalletAppService walletAppService, ILogger<ExpensesController> logger)
        {
            _expenseAppService = expenseAppService;
            _categoryAppService = categoryAppService;
            _walletAppService = walletAppService;
            _logger = logger;
>>>>>>> master
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
            var categoryId = expense.Category.Id;
            var category = await _categoryAppService.GetCategoryByIdAsync(categoryId);

            if (category != null)
            {
<<<<<<< HEAD
                // Asignar el objeto de categoría completo a expense.Category
                expense.Category = category;
=======
                // Actualizar los valores de la categoría en el objeto Expense
                expense.Category = category;

            }
            // Obtener el wallet original mediante su ID
            var walletId = expense.WalletId;
            var wallet = await _walletAppService.GetWalletByIdAsync(walletId);

            if (wallet != null)
            {
                // Actualizar el walletId en el objeto Expense
                expense.WalletId = wallet.Id;
>>>>>>> master
            }

            _logger.LogInformation($"Created expense: {expense}");
            await _expenseAppService.CreateExpenseAsync(expense);
            return Ok(expense);
        }

        [HttpPut("update")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> UpdateExpense(ExpenseDTO expense)
        {
            //var categoryId = expense.Category.Id;
            //var category = await _categoryAppService.GetCategoryByIdAsync(categoryId);

<<<<<<< HEAD
            //if (category != null)
            //{
            //    expense.Category.Name = category.Name;
            //    expense.Category.Description = category.Description;
            //    expense.Category.UrlWeb = category.UrlWeb;
            //}

            //await _expenseAppService.UpdateExpenseAsync(expense);
=======
            if (category != null)
            {
                expense.Category = category;

            }

            _logger.LogInformation($"Update expense: {expense}");
            await _expenseAppService.UpdateExpenseAsync(expense);
>>>>>>> master
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
