using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class WalletRepository :  IWalletRepository
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Wallet> _genericRepository;
        private readonly DataBaseContext _dataBaseContext;

        public WalletRepository(IMapper mapper, IGenericRepository<Wallet> genericRepository, DataBaseContext context)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _dataBaseContext = context;
        }
        public async Task<IEnumerable<EntityWallet>> GetAllAsync()
        {
            var wallettDataModel = await _genericRepository.GetAllAsync(_dataBaseContext);
            return _mapper.Map<IEnumerable<EntityWallet>>(wallettDataModel);
        }

        public async Task<EntityWallet> GetByIdAsync(Guid id)
        {
            var wallettDataModel = await _genericRepository.GetByIdAsync(id, _dataBaseContext);
            return _mapper.Map<EntityWallet>(wallettDataModel);
        }

        public async Task AddAsync(EntityWallet wallet)
        {
            var wallettDataModel = _mapper.Map<Wallet>(wallet);
            await _genericRepository.AddAsync(wallettDataModel, _dataBaseContext);
        }

        public async Task UpdateAsync(EntityWallet wallet)
        {
            var wallettDataModel = _mapper.Map<Wallet>(wallet);
            await _genericRepository.UpdateAsync(wallettDataModel, _dataBaseContext);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _genericRepository.DeleteAsync(id, _dataBaseContext);
        }
    }
}
