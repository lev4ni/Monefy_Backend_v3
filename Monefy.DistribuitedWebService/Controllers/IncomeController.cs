﻿using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monefy.DistribuitedWebService.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public class IncomeController : Controller
    {
        private readonly IIncomeAppService _incomeAppService;

        public IncomeController(IIncomeAppService incomeAppService)
        {
            _incomeAppService = incomeAppService;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllIncomes()
        {
            var incomes = await _incomeAppService.GetAllIncomesAsync();
            return Ok(incomes);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetIncome(Guid id)
        {
            var income = await _incomeAppService.GetIncomeByIdAsync(id);

            if (income == null)
            {
                return NotFound();
            }

            return Ok(income);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateIncome(IncomeDTO income)
        {
            await _incomeAppService.CreateIncomeAsync(income);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(Guid id)
        {
            await _incomeAppService.DeleteIncomeAsync(id);
            return Ok();
        }
    }
}