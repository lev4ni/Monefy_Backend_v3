using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;


namespace Monefy.DistribuitedWebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyAppService _currencyAppService;
        private readonly ILogger<CurrenciesController> _logger;

        public CurrenciesController(ICurrencyAppService currencyAppService, ILogger<CurrenciesController> logger)
        {
            _currencyAppService = currencyAppService;
            _logger = logger;
        }
        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllcurrencies()
        {
            var currency = await _currencyAppService.GetAllCurrenciesAsync();
            if (currency == null)
            {
                _logger.LogError("Se ha intentado GetAllcurrencies pero no hay ninguna");
                return NotFound();
            }
            _logger.LogInformation("Currencies obtenidas: " + currency.ToList());
            return Ok(currency);
        }
        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateCurrency(CurrencyDTO currencyDTO)
        {
            await _currencyAppService.CreateCurrencyAsync(currencyDTO);
            _logger.LogInformation("Currency creada con éxito");
            return Ok(currencyDTO);
        }
        [HttpPut("update")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> UpdateCurrency(CurrencyDTO currencyDTO)
        {
            await _currencyAppService.UpdateCurrencyAsync(currencyDTO);
            _logger.LogInformation("Currency actualizada con éxito");
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            await _currencyAppService.DeleteCurrencyAsync(id);
            _logger.LogInformation("Currency eliminada con éxito");
            return Ok();
        }
    }
}
