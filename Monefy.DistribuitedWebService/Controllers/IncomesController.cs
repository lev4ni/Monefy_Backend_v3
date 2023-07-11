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
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    public class IncomesController : Controller
    {
        private readonly IIncomeAppService _incomeAppService;
        private readonly ILogger<IncomesController> _logger;

        public IncomesController(IIncomeAppService incomeAppService, ILogger<IncomesController> logger)
        {
            _incomeAppService = incomeAppService;
            _logger = logger;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeAppService.GetAllIncomesAsync();
            _logger.LogInformation($"Incomes obtenidos: {incomes}");
            return Ok(incomes);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetIncome(int id)
        {
            var income = await _incomeAppService.GetIncomeByIdAsync(id);

            if (income == null)
            {
                _logger.LogError("No hay Incomes");
                return NotFound();
            }
            _logger.LogInformation($"Income: {income}");
            return Ok(income);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateIncome(IncomeDTO income)
        {
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
