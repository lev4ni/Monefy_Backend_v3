using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using System.Web.Http.Filters;

namespace Monefy.DistribuitedWebService.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    public class WalletsController : Controller
    {
        private readonly IWalletAppService _walletAppService;


        public WalletsController(IWalletAppService walletAppService)
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
        public async Task<IActionResult> GetWalletById(int id)
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
        public async Task<IActionResult> DeleteWallet(int id)
        {
            await _walletAppService.DeleteWalletAsync(id);
            return Ok();
        }

        [HttpGet("UsersWallet")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetUsersWallet(int idWallet)
        {
            var users = await _walletAppService.GetUsersWalletAsync(idWallet);
            return Ok(users);
        }

        [HttpGet("{walletId}/incomes")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletIncomes(int walletId)
        {
            var incomes = await _walletAppService.GetWalletIncomesAsync(walletId);
            return Ok(incomes);
        }

        [HttpGet("{walletId}/expenses")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletExpenses(int walletId)
        {
            var expenses = await _walletAppService.GetWalletExpensesAsync(walletId);
            return Ok(expenses);
        }
    }
}
