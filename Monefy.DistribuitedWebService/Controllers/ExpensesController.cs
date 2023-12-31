﻿using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Application.Services;
using Monefy.Infraestructure.DataModels;
using Serilog;
using System.Threading.Tasks;

namespace Monefy.DistribuitedWebService.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    [TypeFilter(typeof(CustomAuthorizationFilter))]
    public class ExpensesController : Controller
    {
        private readonly IExpenseAppService _expenseAppService;

        public ExpensesController(IExpenseAppService expenseAppService)
        {
            _expenseAppService = expenseAppService;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllExpenses()
        {
            var expenses = await _expenseAppService.GetAllExpensesAsync();
            var response = new
            {
                Success = true,
                Message = "Expenses got successfully",
                Data = expenses
            };
            Log.Information("GetAllExpenses: " + expenses.ToList());
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetExpenseById(int id)
        {
            var expense = await _expenseAppService.GetExpenseByIdAsync(id);
            if (expense == null)
            {
                Log.Error("No Expenses yet!");
                return NotFound();
            }
            var response = new
            {
                Success = true,
                Message = "Expense got successfully",
                Data = expense
            };
            Log.Information($"Expense got successfully: {expense}");
            return Ok(response);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateExpense(ExpenseDTO expenseDTO)
        {
            // Valida el objeto expenseDTO utilizando expenseDTOValidator
            var validator = new ExpenseDTOValidator();
            var validationResult = await validator.ValidateAsync(expenseDTO);

            if (!validationResult.IsValid)
            {
                // Si la validación falla, devuelve un BadRequest con los mensajes de error
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(new { Success = false, Message = "Validation error", Errors = errors });
            }
            await _expenseAppService.CreateExpenseAsync(expenseDTO);
            var response = new
            {
                Success = true,
                Message = "Expense created successfully",
                Data = expenseDTO
            };
            Log.Information("Expense created successfully");
            return Ok(response);
        }

        [HttpPut("update")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> UpdateExpense(ExpenseDTO expense)
        {

            await _expenseAppService.UpdateExpenseAsync(expense);
            var response = new
            {
                Success = true,
                Message = "Expenses updated successfully",
                Data = expense
            };
            Log.Information($"Update expense: {expense}");
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expenseAppService.DeleteExpenseAsync(id);
            var response = new
            {
                Success = true,
                Message = "Expense deleted successfully",
                Data = id
            };
            Log.Information($"Delete expense {id}");
            return Ok(response);
        }
    }
}
