using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.Contracts;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class WalletInfraestrucutureService : IWalletInfraestrucutureService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Wallet> _genericRepositoryWallet;
        private readonly IGenericRepository<User> _genericRepositoryUser;
        private readonly DataBaseContext _dataBaseContext;

        public WalletInfraestrucutureService(IMapper mapper, IGenericRepository<Wallet> genericRepositoryWallet, IGenericRepository<User> genericRepositoryUser, DataBaseContext context)
        {
            _mapper = mapper;
            _genericRepositoryWallet = genericRepositoryWallet;
            _genericRepositoryUser = genericRepositoryUser;
            _dataBaseContext = context;
        }
        public async Task<IEnumerable<EntityWallet>> GetAllAsync()
        {
            var walletDataModel = await _genericRepositoryWallet.GetAllAsync(_dataBaseContext);
            return _mapper.Map<IEnumerable<EntityWallet>>(walletDataModel);
        }

        public async Task<EntityWallet> GetByIdAsync(int id)
        {
            var walletDataModel = await _genericRepositoryWallet.GetByIdAsync(id, _dataBaseContext);
            return _mapper.Map<EntityWallet>(walletDataModel);
        }

        public async Task AddAsync(EntityWallet wallet)
        {
            var walletDataModel = _mapper.Map<Wallet>(wallet);

            var existingUser = await _genericRepositoryUser.GetByIdAsync(wallet.User.Id, _dataBaseContext);
            if (existingUser != null)
            {
                walletDataModel.User = existingUser;
                await _genericRepositoryWallet.AddAsync(walletDataModel, _dataBaseContext);
            }
            else
            {
                throw new Exception("User does not exists.");
            }

        }

        public async Task UpdateAsync(EntityWallet wallet)
        {
            var walletDataModel = _mapper.Map<Wallet>(wallet);
            await _genericRepositoryWallet.UpdateAsync(walletDataModel, _dataBaseContext);
        }

        public async Task DeleteAsync(int id)
        {
            await _genericRepositoryWallet.DeleteAsync(id, _dataBaseContext);
        }

        public async Task<IEnumerable<EntityWallet>> GetUsersWalletAsync(int id)
        {

            var user = await _genericRepositoryUser.GetByIdAsync(id, _dataBaseContext);
            if (user != null)
            {
                var userWallets = await _dataBaseContext.Wallet
                    .Where(w => w.User.Id == id)
                    .ToListAsync();

                return _mapper.Map<IEnumerable<EntityWallet>>(userWallets);
            }
            else
            {
                throw new Exception("User does not exist.");
            }

        }
    }
}
