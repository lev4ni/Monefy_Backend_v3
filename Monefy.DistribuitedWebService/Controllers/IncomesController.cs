using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Serilog;

namespace Monefy.DistribuitedWebService.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    public class IncomesController : Controller
    {
        private readonly IIncomeAppService _incomeAppService;

        public IncomesController(IIncomeAppService incomeAppService)
        {
            _incomeAppService = incomeAppService;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeAppService.GetAllIncomesAsync();
            Log.Information($"Incomes obtenidos: {incomes}");

            var response = new
            {
                Success = true,
                Message = "Incomes got successfully",
                Data = incomes
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetIncome(int id)
        {
            var income = await _incomeAppService.GetIncomeByIdAsync(id);

            if (income == null)
            {
                Log.Error("No hay Incomes");
                return NotFound();
            }
            Log.Information($"Income: {income}");
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
