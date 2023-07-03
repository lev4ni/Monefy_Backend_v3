using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class ExpenseRepository : GenericRepository<EntityExpense>, IExpenseRepository
    {
        private readonly IMapper _mapper;

        public ExpenseRepository(DataBaseContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntityExpense>> GetAllAsync()
        {
            var expenseDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityExpense>>(expenseDataModels);
        }

        public async Task<EntityExpense> GetByIdAsync(Guid id)
        {
            var expensetDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<EntityExpense>(expensetDataModel);
        }

        public async Task AddAsync(EntityExpense expense)
        {
            var expensetDataModel = _mapper.Map<EntityExpense>(expense);
            await base.AddAsync(expensetDataModel);
        }

        public async Task UpdateAsync(EntityExpense expense)
        {
            var expensetDataModel = _mapper.Map<EntityExpense>(expense);
            await base.UpdateAsync(expensetDataModel);
        }

        public async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }
 
}
