using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        private readonly IMapper _mapper;

        public CurrencyRepository(CategoryContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Currency>> GetAllAsync()
        {
            var currencyDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<Currency>>(currencyDataModels);
        }

        public async Task<Currency> GetByIdAsync(Guid id)
        {
            var currencytDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<Currency>(currencytDataModel);
        }

        public async Task AddAsync(Currency currency)
        {
            var currencytDataModel = _mapper.Map<Currency>(currency);
            await base.AddAsync(currencytDataModel);
        }

        public async Task UpdateAsync(Currency currency)
        {
            var currencytDataModel = _mapper.Map<Currency>(currency);
            await base.UpdateAsync(currencytDataModel);
        }

        public async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }
}
