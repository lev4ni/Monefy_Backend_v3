using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Application.Implementation;
using Monefy.Infraestructure.DataModels;
using Newtonsoft.Json;

namespace Monefy.DistribuitedWebService.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [Authorize]
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

        [HttpGet("{id}/incomes")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletIncomes(int id)
        {
            var incomes = new List<IncomeDTO>
{
    new IncomeDTO
    {
        Id = 1,
        Category = new CategoryDTO
        {
            Id = 2,
            Name = "Salary",
            Description = "Ingresos del trabajo.",
            UrlWeb = ""
        },
        Amount = 5,
        Description = "May Salary",
        WalletId = 1,
        CreationAt = DateTime.Parse("2020-07-06T20:22:19.1558205Z")
    },
    new IncomeDTO
    {
        Id = 2,
        Category = new CategoryDTO
        {
            Id = 2,
            Name = "Salary",
            Description = "Ingresos del trabajo.",
            UrlWeb = ""
        },
        Amount = 5,
        Description = "July Salary",
        WalletId = 1,
        CreationAt = DateTime.Parse("2020-07-06T20:22:19.1558205Z")
    }
};


            var response = new
            {
                Success = true,
                Message = "Incomes got successfully",
                Data = incomes
            };

            return Ok(response);
        }

        [HttpGet("{id}/expenses")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletExpenses(int id)
        {
            var expenses = new List<ExpenseDTO>
            {
                new ExpenseDTO
                {
                    Id = 1,
                Category = new CategoryDTO
                {
                    Id = 1,
                    Name = "Ropa",
                    Description = "Gastos relacionados con ropa.",
                    UrlWeb = ""
                },
                Amount = 36,
                Description = "Ropa",
                WalletId = 1,
                CreationAt = DateTime.Parse("2023-07-06T20:22:19.1558205Z")
                },
                new ExpenseDTO
                {
                    Id = 1,
                Category = new CategoryDTO
                {
                    Id = 1,
                    Name = "Comida",
                    Description = "Gastos relacionados con comida.",
                    UrlWeb = ""
                },
                Amount = 5,
                Description = "McDonals",
                WalletId = 1,
                CreationAt = DateTime.Parse("2023-07-06T20:22:19.1558205Z")
                }
            };

            var response = new
            {
                Success = true,
                Message = "Expenses got successfully",
                Data = expenses
            };

            return Ok(response);
        }

        [HttpGet("{walletId}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetWalletById(int walletId)
        {
            object wallet = null;
            if (walletId == 1)
            {
                wallet = new
                {
                    Id = 1,
                    Name = "ALL",
                    UserId = 1,
                    CurrencyId = 1,
                    TotalIncome = 5.8,
                    TotalExpent = 3,
                    TotalBalance = 210,
                    CreationAt = DateTime.UtcNow
                };
            }
            else if (walletId == 2)
            {
                wallet = new
                {
                    Id = 2,
                    Name = "CASH",
                    UserId = 1,
                    CurrencyId = 1,
                    TotalIncome = 300,
                    TotalExpent = 100,
                    TotalBalance = 200,
                    CreationAt = DateTime.UtcNow
                };
            }


            var response = new
            {
                Success = true,
                Message = "Wallet got successfully",
                Data = wallet
            };

            return Ok(response);
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
    }
}
