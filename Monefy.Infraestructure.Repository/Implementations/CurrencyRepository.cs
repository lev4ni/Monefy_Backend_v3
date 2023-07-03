using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class CurrencyRepository : GenericRepository<EntityCurrency>, ICurrencyRepository
    {
        private readonly IMapper _mapper;

        public CurrencyRepository(DataBaseContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntityCurrency>> GetAllAsync()
        {
            var currencyDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityCurrency>>(currencyDataModels);
        }

        public async Task<EntityCurrency> GetByIdAsync(Guid id)
        {
            var currencytDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<EntityCurrency>(currencytDataModel);
        }

        public async Task AddAsync(EntityCurrency currency)
        {
            var currencytDataModel = _mapper.Map<EntityCurrency>(currency);
            await base.AddAsync(currencytDataModel);
        }

        public async Task UpdateAsync(EntityCurrency currency)
        {
            var currencytDataModel = _mapper.Map<EntityCurrency>(currency);
            await base.UpdateAsync(currencytDataModel);
        }

        public async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }
}
