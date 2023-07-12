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
            var response = new
            {
                Success = true,
                Message = "Wallet got successfully",
                Data = wallets
            };
            Log.Information($"Wallets got successfully: {wallets}");
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletById(int id)
        {
            var wallet = await _walletAppService.GetWalletByIdAsync(id);
            if (wallet == null)
            {
                Log.Error($"No wallets yet");
                return NotFound();
            }
            var response = new
            {
                Success = true,
                Message = "Wallet got successfully",
                Data = wallet
            };
            Log.Information($"Wallet got successfully: {id}");
            return Ok(response);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateWallet(WalletDTO walletDTO)
        {
            var wallet = await _walletAppService.CreateWalletAsync(walletDTO);
            var response = new
            {
                Success = true,
                Message = "Wallet created successfully",
                Data = wallet
            };
            Log.Information($"Wallet created: {wallet}");
            return Ok(response);
        }

        [HttpGet("UsersWallet")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetUsersWallet(int idWallet)
        {
            var users = await _walletAppService.GetUsersWalletAsync(idWallet);
            var response = new
            {
                Success = true,
                Message = "Users from wallet got successfully",
                Data = users
            };
            Log.Information($"Users from Wallet --> ID wallet: {idWallet}");
            return Ok(response);
        }

        [HttpGet("{walletId}/incomes")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletIncomes(int walletId)
        {
            var incomes = await _walletAppService.GetWalletIncomesAsync(walletId);
            var response = new
            {
                Success = true,
                Message = "Incomes from wallet got successfully",
                Data = incomes
            };
            Log.Information($"Incomes from Wallet --> ID wallet: {walletId}");
            return Ok(response);
        }

        [HttpGet("{walletId}/expenses")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletExpenses(int walletId)
        {
            var expenses = await _walletAppService.GetWalletExpensesAsync(walletId);
            var response = new
            {
                Success = true,
                Message = "Wallet expenses got successfully",
                Data = expenses
            };
            Log.Information($"Expenses from Wallet --> ID Wallet: {walletId}");
            return Ok(response);
        }

        [HttpPut("update")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> UpdateWallet(WalletDTO walletDTO)
        {
            var wallet = await _walletAppService.UpdateWalletAsync(walletDTO);
            var response = new
            {
                Success = true,
                Message = "Wallet updated successfully",
                Data = wallet
            };
            Log.Information($"Wallet updated successfully: {wallet}");
            return Ok(wallet);
        }

        [HttpDelete("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> DeleteWallet(int id)
        {
            var wallet = await _walletAppService.DeleteWalletAsync(id);
            var response = new
            {
                Success = true,
                Message = "Wallet deleted successfully",
                Data = wallet
            };
            Log.Information($"Wallet Deleted: {id}");
            return Ok(response);
        }
    }
}
