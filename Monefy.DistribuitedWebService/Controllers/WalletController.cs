using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.Implementation;

namespace Monefy.DistribuitedWebService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : Controller
    {
        private readonly IWalletAppService _walletAppService;
        public WalletController(IWalletAppService walletAppService)
        {
            _walletAppService = walletAppService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWallets()
        {
            var wallet = await _walletAppService.GetAllWalletsAsync();
            if (wallet == null)
            {
                return NotFound();
            }
            return Ok(wallet);
        }
    }
}
