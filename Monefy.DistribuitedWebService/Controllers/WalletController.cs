using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Application.Implementation;

namespace Monefy.DistribuitedWebService.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class WalletController : Controller
    {
        private readonly IWalletAppService _walletAppService;

        public WalletController(IWalletAppService walletAppService)
        {
            _walletAppService = walletAppService;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllWallets()
        {
            var wallets = await _walletAppService.GetAllWalletsAsync();
            return Ok(wallets);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletById(Guid id)
        {
            var wallet = await _walletAppService.GetWalletByIdAsync(id);
            if (wallet == null)
            {
                return NotFound();
            }
            return Ok(wallet);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateWallet(WalletDTO wallet)
        {
            await _walletAppService.CreateWalletAsync(wallet);
            return Ok();
        }

        [HttpPost("update")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> UpdateWallet(WalletDTO wallet)
        {
            await _walletAppService.UpdateWalletAsync(wallet);
            return Ok(wallet);
        }

        [HttpDelete("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> DeleteWallet(Guid id)
        {
            await _walletAppService.DeleteWalletAsync(id);
            return Ok();
        }
    }
}
