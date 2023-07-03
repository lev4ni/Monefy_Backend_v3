using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class IncomeRepository : GenericRepository<EntityIncome>, IIncomeRepository
    {
        private readonly IMapper _mapper;

        public IncomeRepository(DataBaseContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntityIncome>> GetAllAsync()
        {
            var incomeDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityIncome>>(incomeDataModels);
        }

        public async Task<EntityIncome> GetByIdAsync(Guid id)
        {
            var incomeDataModels = await base.GetByIdAsync(id);
            return _mapper.Map<EntityIncome>(incomeDataModels);
        }

        public async Task AddAsync(EntityCurrency income)
        {
            var incomeDataModels = _mapper.Map<EntityIncome>(income);
            await base.AddAsync(incomeDataModels);
        }

        public async Task UpdateAsync(EntityIncome income)
        {
            var incomeDataModels = _mapper.Map<EntityIncome>(income);
            await base.UpdateAsync(incomeDataModels);
        }

        public async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }
}
