using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class WalletRepository : GenericRepository<EntityWallet>, IWalletRepository
    {
        private readonly IMapper _mapper;

        public WalletRepository(DataBaseContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntityWallet>> GetAllAsync()
        {
            var wallettDataModel = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityWallet>>(wallettDataModel);
        }

        public async Task<EntityWallet> GetByIdAsync(Guid id)
        {
            var wallettDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<EntityWallet>(wallettDataModel);
        }

        public async Task AddAsync(EntityWallet wallet)
        {
            var wallettDataModel = _mapper.Map<EntityWallet>(wallet);
            await base.AddAsync(wallettDataModel);
        }

        public async Task UpdateAsync(EntityWallet wallet)
        {
            var wallettDataModel = _mapper.Map<EntityWallet>(wallet);
            await base.UpdateAsync(wallettDataModel);
        }

        public async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }
}
