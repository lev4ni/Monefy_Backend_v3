using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        private readonly IMapper _mapper;

        public ExpenseRepository(ExpenseContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Expense>> GetAllAsync()
        {
            var expenseDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<Expense>>(expenseDataModels);
        }

        public async Task<Expense> GetByIdAsync(Guid id)
        {
            var expensetDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<Expense>(expensetDataModel);
        }

        public async Task AddAsync(Expense expense)
        {
            var expensetDataModel = _mapper.Map<Expense>(expense);
            await base.AddAsync(expensetDataModel);
        }

        public async Task UpdateAsync(Expense expense)
        {
            var expensetDataModel = _mapper.Map<Expense>(expense);
            await base.UpdateAsync(expensetDataModel);
        }

        public async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }
 
}
