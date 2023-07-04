using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Currency> _genericRepository;
        private readonly DataBaseContext _dataBaseContext;

        public CurrencyRepository(IMapper mapper, IGenericRepository<Currency> genericRepository, DataBaseContext context)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _dataBaseContext = context;
        }

        public async Task<IEnumerable<EntityCurrency>> GetAllAsync()
        {
            var currencyDataModels = await _genericRepository.GetAllAsync(_dataBaseContext);
            return _mapper.Map<IEnumerable<EntityCurrency>>(currencyDataModels);
        }

        public async Task<EntityCurrency> GetByIdAsync(Guid id)
        {
            var currencytDataModel = await _genericRepository.GetByIdAsync(id, _dataBaseContext);
            return _mapper.Map<EntityCurrency>(currencytDataModel);
        }

        public async Task AddAsync(EntityCurrency currency)
        {
            var currencytDataModel = _mapper.Map<Currency>(currency);
            await _genericRepository.AddAsync(currencytDataModel, _dataBaseContext);
        }

        public async Task UpdateAsync(EntityCurrency currency)
        {
            var currencytDataModel = _mapper.Map<Currency>(currency);
            await _genericRepository.UpdateAsync(currencytDataModel, _dataBaseContext);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _genericRepository.DeleteAsync(id, _dataBaseContext);
        }
    }
}
