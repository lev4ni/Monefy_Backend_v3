using Abp.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.services;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public WalletRepository(IMapper mapper, DataBaseContext context) : base(context)
        {
            _mapper = mapper;
            _dataBaseContext = context;
        }
        public new async Task<IEnumerable<EntityWallet>> GetAllAsync()
        {
            var walletsDM = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityWallet>>(walletsDM);
        }

        public new async Task<EntityWallet> GetByIdAsync(int id)
        {
            var walletDataModel = await _dataBaseContext.Set<Wallet>().FindAsync(id);
            _dataBaseContext.Entry(walletDataModel.User).State = EntityState.Detached;
            _dataBaseContext.Entry(walletDataModel).State = EntityState.Detached;
            return _mapper.Map<EntityWallet>(walletDataModel);
        }

        public async Task AddAsync(EntityWallet wallet)
        {
            var walletDataModel = _mapper.Map<Wallet>(wallet);
            _dataBaseContext.Attach(walletDataModel.User);
            await base.AddAsync(walletDataModel);
        }

        public new async Task UpdateAsync(EntityWallet wallet)
        {
            var walletDataModel = _mapper.Map<Wallet>(wallet);
            _dataBaseContext.Attach(walletDataModel);
            _dataBaseContext.Entry(walletDataModel).State = EntityState.Modified;
        }

        public async Task<IEnumerable<EntityWallet>> GetUserWalletsAsync(int id)
        {
            var userWallets = await _dataBaseContext.Wallet
                    .Where(w => w.UserId == id)
                    .ToListAsync();

            return _mapper.Map<IEnumerable<EntityWallet>>(userWallets);

        }

        public async Task<EntityWallet> getWalletByUserAndName(int id, string name)
        {
            var walletDataModel = await _dataBaseContext.Wallet.FirstOrDefaultAsync(w => w.Name == "all" && w.UserId == id);
            if (walletDataModel != null)
            {
                _dataBaseContext.Entry(walletDataModel.User).State = EntityState.Detached;
                _dataBaseContext.Entry(walletDataModel).State = EntityState.Detached;
                return _mapper.Map<EntityWallet>(walletDataModel);
            }
            else throw new ArgumentException();
        }
    }
}
