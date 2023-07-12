using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
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
                Log.Error("Se ha intentado GetAllcurrencies pero no hay ninguna");
                return NotFound();
            }
            Log.Information("Currencies obtenidas: " + currency.ToList());
            return Ok(currency);
        }
        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateCurrency(CurrencyDTO currencyDTO)
        {
            await _currencyAppService.CreateCurrencyAsync(currencyDTO);
            Log.Information("Currency creada con éxito");
            return Ok(currencyDTO);
        }
        [HttpPut("update")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> UpdateCurrency(CurrencyDTO currencyDTO)
        {
            await _currencyAppService.UpdateCurrencyAsync(currencyDTO);
            Log.Information("Currency actualizada con éxito");
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            await _currencyAppService.DeleteCurrencyAsync(id);
            Log.Information("Currency eliminada con éxito");
            return Ok();
        }
    }
}
