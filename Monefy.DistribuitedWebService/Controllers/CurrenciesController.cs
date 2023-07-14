using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Application.Services;
using Monefy.Infraestructure.DataModels;
using Serilog;

namespace Monefy.DistribuitedWebService.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyAppService _currencyAppService;
        public CurrenciesController(ICurrencyAppService currencyAppService)
        {
            _currencyAppService = currencyAppService;
        }
        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllcurrencies()
        {
            var currency = await _currencyAppService.GetAllCurrenciesAsync();
            if (currency == null)
            {
                Log.Error("Not currencies yet!");
                return NotFound();
            }
            var response = new
            {
                Success = true,
                Message = "Currencies got successfully",
                Data = currency
            };

            Log.Information("Currencies got: " + currency.ToList());
            return Ok(response);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateCurrency(CurrencyDTO currencyDTO)
        {
            // Valida el objeto currencyDTO utilizando currencyDTOValidator
            var validator = new CurrencyDTOValidator();
            var validationResult = await validator.ValidateAsync(currencyDTO);

            if (!validationResult.IsValid)
            {
                // Si la validación falla, devuelve un BadRequest con los mensajes de error
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(new { Success = false, Message = "Validation error", Errors = errors });
            }

            var currency =  await _currencyAppService.CreateCurrencyAsync(currencyDTO);
            var response = new
            {
                Success = true,
                Message = "Currency got successfully",
                Data = currency
            };

            Log.Information("Currency got successfully");
            return Ok(response);
        }

        [HttpPut("update")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> UpdateCurrency(CurrencyDTO currencyDTO)
        {
            var currency = await _currencyAppService.UpdateCurrencyAsync(currencyDTO);
            var response = new
            {
                Success = true,
                Message = "Currency updated successfully",
                Data = currency
            };

            Log.Information("Currency updated successfully");
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            var currency = await _currencyAppService.DeleteCurrencyAsync(id);
            var response = new
            {
                Success = true,
                Message = "Currency got successfully",
                Data = currency
            };
            Log.Information("Currency deleted successfully");
            return Ok(response);
        }
    }
}
