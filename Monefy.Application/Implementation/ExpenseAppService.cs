﻿using AutoMapper;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Application.Implementation
{
    public class ExpenseAppService : IExpenseAppService
    {
        private readonly IMapper _mapper;
        private readonly IExpenseBusinessService _expenseBusinessService;
        public ExpenseAppService(IMapper mapper, IExpenseBusinessService expenseBusinessService)
        {
            _mapper = mapper;
			_expenseBusinessService = expenseBusinessService;
        }

        public async Task CreateExpenseAsync(ExpenseDTO ExpenseDTO)
        {
            await _expenseBusinessService.CreateExpenseAsync(_mapper.Map<EntityExpense>(ExpenseDTO));
        }

        public async Task DeleteExpenseAsync(int id)
        {
            await _expenseBusinessService.DeleteExpenseAsync(id);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAllExpensesAsync()
        {
            var ExpenseList = await _expenseBusinessService.GetAllExpensesAsync();
            return _mapper.Map<IEnumerable<ExpenseDTO>>(ExpenseList);
        }

        public async Task<ExpenseDTO> GetExpenseByIdAsync(int id)
        {
            var Expense = await _expenseBusinessService.GetExpenseByIdAsync(id);
            return _mapper.Map<ExpenseDTO>(Expense);
        }

        public async Task UpdateExpenseAsync(ExpenseDTO ExpenseDTO)
        {
            await _expenseBusinessService.UpdateExpenseAsync(_mapper.Map<EntityExpense>(ExpenseDTO));
        }
    }
}
