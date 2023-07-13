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
            return _mapper.Map<EntityWallet>(walletDataModel);
        }

        public async Task AddAsync(EntityWallet wallet)
        {
            var walletDataModel = _mapper.Map<Wallet>(wallet);
            var userEF = await _dataBaseContext.Set<User>().FindAsync(walletDataModel.User.Id);
            if (userEF != null)
            {
                walletDataModel.User = userEF;
                await base.AddAsync(walletDataModel);
            }
            else throw new NullReferenceException();
           
        }

        public new async Task UpdateAsync(EntityWallet wallet)
        {
            var walletDataModel = _mapper.Map<Wallet>(wallet);
            var walletEF = await _dataBaseContext.Wallet.FindAsync(walletDataModel.Id);
            if (walletEF != null)
            {
                _dataBaseContext.Entry(walletEF).CurrentValues.SetValues(walletDataModel);
            }
            else throw new NullReferenceException();
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
                return _mapper.Map<EntityWallet>(walletDataModel);
            }
            else throw new ArgumentException();
        }
    }
}
