using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Infraestructure.DataModels;
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
            var response = new
            {
                Success = true,
                Message = "Incomes got successfully",
                Data = incomes
            };

            Log.Information($"Incomes obtenidos: {incomes}");
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetIncome(int id)
        {
            var income = await _incomeAppService.GetIncomeByIdAsync(id);

            if (income == null)
            {
                Log.Error("No Incomes yet");
                return NotFound();
            }
            var response = new
            {
                Success = true,
                Message = "Income got successfully",
                Data = income
            };
            Log.Information($"Income: {income}");
            return Ok(response);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateIncome(IncomeDTO incomeDTO)
        {
            var income = await _incomeAppService.CreateIncomeAsync(incomeDTO);
            var response = new
            {
                Success = true,
                Message = "Income created successfully",
                Data = income
            };
            Log.Information($"Income created successfully {incomeDTO}");
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            var income = await _incomeAppService.DeleteIncomeAsync(id);
            var response = new
            {
                Success = true,
                Message = "Currency got successfully",
                Data = income
            };
            Log.Information($"Delete income: {income}");
            return Ok(response);
        }
    }
}
