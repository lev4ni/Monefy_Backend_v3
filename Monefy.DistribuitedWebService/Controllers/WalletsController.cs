﻿using Microsoft.AspNetCore.Authorization;
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
        private readonly ILogger<WalletsController> _logger;

        public WalletsController(IWalletAppService walletAppService, ILogger<WalletsController> logger)
        {
            _walletAppService = walletAppService;
            _logger = logger;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllWallets()
        {
            var wallets = await _walletAppService.GetAllWalletsAsync();
            _logger.LogInformation($"Wallets obtenidas: {wallets}");
            return Ok(wallets);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletById(int id)
        {
            var wallet = await _walletAppService.GetWalletByIdAsync(id);
            if (wallet == null)
            {
                _logger.LogError($"No hay wallets");
                return NotFound();
            }
            _logger.LogInformation($"Wallet obtenida: {id}");
            return Ok(wallet);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateWallet(WalletDTO wallet)
        {
            await _walletAppService.CreateWalletAsync(wallet);
            _logger.LogInformation($"Wallet creada: {wallet}");
            return Ok();
        }

        [HttpGet("UsersWallet")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetUsersWallet(int idWallet)
        {
            var users = await _walletAppService.GetUsersWalletAsync(idWallet);
            _logger.LogInformation($"Users de Wallet: {idWallet}");
            return Ok(users);
        }

        [HttpGet("{walletId}/incomes")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletIncomes(int walletId)
        {
            var incomes = await _walletAppService.GetWalletIncomesAsync(walletId);
            _logger.LogInformation($"Incomes de Wallet: {walletId}");
            return Ok(incomes);
        }

        [HttpGet("{walletId}/expenses")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletExpenses(int walletId)
        {
            var expenses = await _walletAppService.GetWalletExpensesAsync(walletId);
            _logger.LogInformation($"Expenses de Wallet: {walletId}");
            return Ok(expenses);
        }

        [HttpPut("update")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> UpdateWallet(WalletDTO wallet)
        {
            await _walletAppService.UpdateWalletAsync(wallet);
            _logger.LogInformation($"Wallet actualizada: {wallet}");
            return Ok(wallet);
        }

        [HttpDelete("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> DeleteWallet(int id)
        {

            await _walletAppService.DeleteWalletAsync(id);
            _logger.LogInformation($"Wallet borrada: {id}");
            return Ok();
        }

    }
}
