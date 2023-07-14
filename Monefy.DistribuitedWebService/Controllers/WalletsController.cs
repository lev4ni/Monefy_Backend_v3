using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Application.Services;
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
            // Valida el objeto walleyDTO utilizando walletDTOValidator
            var validator = new WalletDTOValidator();
            var validationResult = await validator.ValidateAsync(walletDTO);

            if (!validationResult.IsValid)
            {
                // Si la validación falla, devuelve un BadRequest con los mensajes de error
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(new { Success = false, Message = "Validation error", Errors = errors });
            }

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

        [HttpGet("incomes")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletIncomes(int walletId, DateTime initialDate, DateTime finalDate)
        {
            var incomes = await _walletAppService.GetWalletIncomesAsync(walletId, initialDate, finalDate);
            Log.Information($"Incomes from Wallet --> ID wallet: {walletId}");
            var response = new
            {
                Success = true,
                Message = "Wallet incomes got successfully",
                Data = incomes
            };

            return Ok(response);
        }

        [HttpGet("expenses")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletExpenses(int walletId, DateTime initialDate, DateTime finalDate)
        {
            var expenses = await _walletAppService.GetWalletExpensesAsync(walletId, initialDate, finalDate);
            Log.Information($"Expenses from Wallet --> ID Wallet: {walletId}");
            var response = new
            {
                Success = true,
                Message = "Wallet expenses got successfully",
                Data = expenses
            };

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
            return Ok(response);
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

        [HttpGet("{id}/categories")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetExpensesWithCategory(int walletId, DateTime initialDate, DateTime finalDate)
        {
            var CategoryExpenses = await _walletAppService.GetCategoriesWithExpenses(walletId, initialDate, finalDate);
            var response = new
            {
                Success = true,
                Message = "Wallet list expenses successfully",
                Data = CategoryExpenses
            };
            Log.Information($"List expenses done!");
            return Ok(response);
        }
    }
}
