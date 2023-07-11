using AutoMapper;
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

        public WalletRepository(IMapper mapper, IGenericRepository<User> genericRepositoryUser, DataBaseContext context) : base(context)
        {
            _mapper = mapper;
        }
        public new async Task<IEnumerable<EntityWallet>> GetAllAsync()
        {
            var walletsDM = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityWallet>>(walletsDM);
        }

        public new async Task<EntityWallet> GetByIdAsync(int id)
        {
            var walletDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<EntityWallet>(walletDataModel);
        }

        public async Task AddAsync(EntityWallet wallet)
        {
            var walletDataModel = _mapper.Map<Wallet>(wallet);
            await base.AddAsync(walletDataModel);
        }

        public async Task UpdateAsync(EntityWallet wallet)
        {
            var walletDataModel = _mapper.Map<Wallet>(wallet);
            await base.UpdateAsync(walletDataModel);
        }

        public async Task<IEnumerable<EntityWallet>> GetUsersWalletAsync(int id)
        {
            var userWallets = await base.GetByIdAsync(id);
            return _mapper.Map<IEnumerable<EntityWallet>>(userWallets);
        }
    }
}
