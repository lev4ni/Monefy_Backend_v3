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
        private readonly IGenericRepository<User> _genericRepositoryUser;
        private readonly DataBaseContext _dataBaseContext;

        public WalletRepository(IMapper mapper, IGenericRepository<User> genericRepositoryUser, DataBaseContext context) : base(context)
        {
            _mapper = mapper;
            _genericRepositoryUser = genericRepositoryUser;
            _dataBaseContext = context;
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
            _dataBaseContext.Attach(walletDataModel.User);
            await base.AddAsync(walletDataModel);
        }

        public async Task UpdateAsync(EntityWallet wallet)
        {
            var walletDataModel = _mapper.Map<Wallet>(wallet);
            await base.UpdateAsync(walletDataModel);
        }

        public async Task<IEnumerable<EntityWallet>> GetUsersWalletAsync(int id)
        {

            var userWallets = await _genericRepositoryUser.GetByIdAsync(id);
            return _mapper.Map<IEnumerable<EntityWallet>>(userWallets);
            /*if (user != null)
            {
                var userWallets = await _dataBaseContext.Wallet
                    .Where(w => w.User.Id == id)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<EntityWallet>>(userWallets);
            }
            else
            {
                throw new Exception("User does not exist.");
            }*/

        }
    }
}
