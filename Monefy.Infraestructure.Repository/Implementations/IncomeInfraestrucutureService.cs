using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.Contracts;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class IncomeInfraestrucutureService : IIncomeInfraestrucutureService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Income> _genericRepository;
        private readonly DataBaseContext _dataBaseContext;

        public IncomeInfraestrucutureService(IMapper mapper, IGenericRepository<Income> genericRepository, DataBaseContext context)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _dataBaseContext = context;
        }

        public async Task<IEnumerable<EntityIncome>> GetAllAsync()
        {
            var incomeDataModels = await _genericRepository.GetAllAsync(_dataBaseContext);
            return _mapper.Map<IEnumerable<EntityIncome>>(incomeDataModels);
        }

        public async Task<EntityIncome> GetByIdAsync(Guid id)
        {
            var incomeDataModels = await _genericRepository.GetByIdAsync(id, _dataBaseContext);
            return _mapper.Map<EntityIncome>(incomeDataModels);
        }

        public async Task AddAsync(EntityIncome income)
        {
            var incomeDataModels = _mapper.Map<Income>(income);
            await _genericRepository.AddAsync(incomeDataModels, _dataBaseContext);
        }

        public async Task UpdateAsync(EntityIncome income)
        {
            var incomeDataModels = _mapper.Map<Income>(income);
            await _genericRepository.UpdateAsync(incomeDataModels, _dataBaseContext);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _genericRepository.DeleteAsync(id, _dataBaseContext);
        }
    }
}
