using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class WalletRepository : GenericRepository<Wallet>, IWalletRepository
    {
        private readonly IMapper _mapper;

        public WalletRepository(CategoryContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<Wallet>> GetAllAsync()
        {
            var wallettDataModel = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<Wallet>>(wallettDataModel);
        }

        public async Task<Wallet> GetByIdAsync(Guid id)
        {
            var wallettDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<Wallet>(wallettDataModel);
        }

        public async Task AddAsync(Wallet wallet)
        {
            var wallettDataModel = _mapper.Map<Wallet>(wallet);
            await base.AddAsync(wallettDataModel);
        }

        public async Task UpdateAsync(Wallet wallet)
        {
            var wallettDataModel = _mapper.Map<Wallet>(wallet);
            await base.UpdateAsync(wallettDataModel);
        }

        public async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }
}
