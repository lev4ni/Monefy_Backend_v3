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
        private readonly IExpenseBusinessService _ExpenseBusinessService;
        public ExpenseAppService(IMapper mapper, IExpenseBusinessService ExpenseBusinessService)
        {
            _mapper = mapper;
            _ExpenseBusinessService = ExpenseBusinessService;
        }

        public async Task CreateExpenseAsync(ExpenseDTO ExpenseDTO)
        {
            await _ExpenseBusinessService.CreateExpenseAsync(_mapper.Map<EntityExpense>(ExpenseDTO));
        }

        public async Task DeleteExpenseAsync(Guid id)
        {
            await _ExpenseBusinessService.DeleteExpenseAsync(id);
        }

        public async Task<IEnumerable<ExpenseDTO>> GetAllExpensesAsync()
        {
            var ExpenseList = await _ExpenseBusinessService.GetAllExpensesAsync();
            return _mapper.Map<IEnumerable<ExpenseDTO>>(ExpenseList);
        }

        public async Task<ExpenseDTO> GetExpenseByIdAsync(Guid id)
        {
            var Expense = await _ExpenseBusinessService.GetExpenseByIdAsync(id);
            return _mapper.Map<ExpenseDTO>(Expense);
        }

        public async Task UpdateExpenseAsync(ExpenseDTO ExpenseDTO)
        {
            await _ExpenseBusinessService.UpdateExpenseAsync(_mapper.Map<EntityExpense>(ExpenseDTO));
        }
    }
}
