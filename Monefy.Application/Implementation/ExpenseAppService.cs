using AutoMapper;
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

        public async Task<ExpenseDTO> CreateExpenseAsync(ExpenseDTO expenseDTO)
        {
            await _expenseBusinessService.CreateExpenseAsync(_mapper.Map<EntityExpense>(expenseDTO));
            return expenseDTO;
        }
        public async Task<ExpenseDTO> GetExpenseByIdAsync(int id)
        {
            var Expense = await _expenseBusinessService.GetExpenseByIdAsync(id);
            return _mapper.Map<ExpenseDTO>(Expense);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAllExpensesAsync()
        {
            var ExpenseList = await _expenseBusinessService.GetAllExpensesAsync();
            return _mapper.Map<IEnumerable<ExpenseDTO>>(ExpenseList);
        }


        public async Task<ExpenseDTO> UpdateExpenseAsync(ExpenseDTO expenseDTO)
        {
            await _expenseBusinessService.UpdateExpenseAsync(_mapper.Map<EntityExpense>(expenseDTO));
            return expenseDTO;
        }
        public async Task<ExpenseDTO> DeleteExpenseAsync(int id)
        {
            await _expenseBusinessService.DeleteExpenseAsync(id);
            return _mapper.Map<ExpenseDTO>(id);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetExpensesPerMonthAsync(int walletId, DateTime startDate, DateTime endDate)
        {
            var expensesMonth =  await _expenseBusinessService.GetExpensesPerMonth(walletId, startDate, endDate);
            return _mapper.Map<IEnumerable<ExpenseDTO>>(expensesMonth);
        }
    }
}
