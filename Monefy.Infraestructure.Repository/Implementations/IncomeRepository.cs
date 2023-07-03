using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class IncomeRepository : GenericRepository<Income>, IIncomeRepository
    {
        private readonly IMapper _mapper;

        public IncomeRepository(IncomeContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Income>> GetAllAsync()
        {
            var incomeDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<Income>>(incomeDataModels);
        }

        public async Task<Income> GetByIdAsync(Guid id)
        {
            var incomeDataModels = await base.GetByIdAsync(id);
            return _mapper.Map<Income>(incomeDataModels);
        }

        public async Task AddAsync(Currency income)
        {
            var incomeDataModels = _mapper.Map<Income>(income);
            await base.AddAsync(incomeDataModels);
        }

        public async Task UpdateAsync(Income income)
        {
            var incomeDataModels = _mapper.Map<Income>(income);
            await base.UpdateAsync(incomeDataModels);
        }

        public async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }
}
