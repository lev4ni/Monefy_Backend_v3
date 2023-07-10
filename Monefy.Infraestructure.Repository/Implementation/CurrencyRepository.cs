using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.services;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class CurrencyRepository : GenericRepository<Currency>, ICurrencyRepository
    {
        private readonly IMapper _mapper;

        public CurrencyRepository(IMapper mapper, DataBaseContext context) : base(context)
        {
            _mapper = mapper;
        }

        public new async Task<IEnumerable<EntityCurrency>> GetAllAsync()
        {
            var currencyDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityCurrency>>(currencyDataModels);
        }

        public new async Task<EntityCurrency> GetByIdAsync(int id)
        {
            var currencytDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<EntityCurrency>(currencytDataModel);
        }

        public async Task AddAsync(EntityCurrency currency)
        {
            var currencytDataModel = _mapper.Map<Currency>(currency);
            await base.AddAsync(currencytDataModel);
        }

        public async Task UpdateAsync(EntityCurrency currency)
        {
            var currencytDataModel = _mapper.Map<Currency>(currency);
            await base.UpdateAsync(currencytDataModel);
        }
    }
}
