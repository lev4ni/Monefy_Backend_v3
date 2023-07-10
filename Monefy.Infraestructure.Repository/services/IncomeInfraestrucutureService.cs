using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IGenericRepository<Income> _genericRepositoryIncome;
        private readonly IGenericRepository<Wallet> _genericRepositoryWallet;
        private readonly DataBaseContext _dataBaseContext;

        public IncomeInfraestrucutureService(IMapper mapper, IGenericRepository<Income> genericRepositoryIncome, IGenericRepository<Wallet> genericRepositoryWallet, DataBaseContext context)
        {
            _mapper = mapper;
            _genericRepositoryIncome = genericRepositoryIncome;
            _genericRepositoryWallet = genericRepositoryWallet;
            _dataBaseContext = context;
        }

        public async Task<IEnumerable<EntityIncome>> GetAllAsync()
        {
            var incomeDataModels = await _genericRepositoryIncome.GetAllAsync(_dataBaseContext);
            return _mapper.Map<IEnumerable<EntityIncome>>(incomeDataModels);
        }

        public async Task<EntityIncome> GetByIdAsync(int id)
        {
            var incomeDataModels = await _genericRepositoryIncome.GetByIdAsync(id, _dataBaseContext);
            return _mapper.Map<EntityIncome>(incomeDataModels);
        }

        public async Task AddAsync(EntityIncome income)
        {
            var incomeDataModels = _mapper.Map<Income>(income);
            await _genericRepositoryIncome.AddAsync(incomeDataModels, _dataBaseContext);
        }

        public async Task UpdateAsync(EntityIncome income)
        {
            var incomeDataModels = _mapper.Map<Income>(income);
            await _genericRepositoryIncome.UpdateAsync(incomeDataModels, _dataBaseContext);
        }

        public async Task DeleteAsync(int id)
        {
            await _genericRepositoryIncome.DeleteAsync(id, _dataBaseContext);
        }

        public async Task<IEnumerable<EntityIncome>> GetWalletIncomesAsync(int walletId)
        {
            var wallet = await _genericRepositoryWallet.GetByIdAsync(walletId, _dataBaseContext);
            if (wallet != null)
            {
                var walletIncomes = await _dataBaseContext.Income
                    .Where(i => i.Wallet.Id == walletId)
                    .ToListAsync();
                return _mapper.Map<IEnumerable<EntityIncome>>(walletIncomes);
            }
            else
            {
                throw new Exception("Wallet does not exist.");
            }
        }
    }
}
