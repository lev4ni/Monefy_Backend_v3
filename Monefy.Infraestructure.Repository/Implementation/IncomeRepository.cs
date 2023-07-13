using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.services;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class IncomeRepository : GenericRepository<Income>, IIncomeRepository
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public IncomeRepository(IMapper mapper, DataBaseContext context) : base(context)
        {
            _mapper = mapper;
            _dataBaseContext = context;
        }

        public new async Task<IEnumerable<EntityIncome>> GetAllAsync()
        {
            var incomeDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityIncome>>(incomeDataModels);
        }

        public new async Task<EntityIncome> GetByIdAsync(int id)
        {
            var incomeDataModels = await base.GetByIdAsync(id);
            return _mapper.Map<EntityIncome>(incomeDataModels);
        }

        public async Task AddAsync(EntityIncome income)
        {
            var incomeDataModels = _mapper.Map<Income>(income);
            _dataBaseContext.Attach(incomeDataModels.Category);
            _dataBaseContext.Attach(incomeDataModels.Wallet);
            await base.AddAsync(incomeDataModels);
        }

        public async Task UpdateAsync(EntityIncome income)
        {
            var incomeDataModels = _mapper.Map<Income>(income);
            await base.UpdateAsync(incomeDataModels);
        }

        public async Task<IEnumerable<EntityIncome>> GetWalletIncomesAsync(int walletId, DateTime initialDate, DateTime finalDate)
        {
            var walletIncomes = await _dataBaseContext.Income
                    .Where(i => i.Wallet.Id == walletId && i.Wallet.CreatedAt >= initialDate && i.Wallet.CreatedAt <= finalDate)
                    .ToListAsync();
            return _mapper.Map<IEnumerable<EntityIncome>>(walletIncomes);
        }
    }
}
