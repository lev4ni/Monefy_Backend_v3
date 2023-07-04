using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<User> _genericRepository;
        private readonly DataBaseContext _dataBaseContext;

        public UserRepository(IMapper mapper, IGenericRepository<User> genericRepository, DataBaseContext context)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
            _dataBaseContext = context;
        }

        public async Task<IEnumerable<EntityUser>> GetAllAsync()
        {
            var userDataModels = await _genericRepository.GetAllAsync(_dataBaseContext);
            return _mapper.Map<IEnumerable<EntityUser>>(userDataModels);
        }

        public async Task<EntityUser> GetByIdAsync(Guid id)
        {
            var userDataModel = await _genericRepository.GetByIdAsync(id, _dataBaseContext);
            return _mapper.Map<EntityUser>(userDataModel);
        }

        public async Task AddAsync(EntityUser user)
        {
            var userDataModel = _mapper.Map<User>(user);
            await _genericRepository.AddAsync(userDataModel, _dataBaseContext);
        }

        public async Task UpdateAsync(EntityUser user)
        {
            var usertDataModel = _mapper.Map<User>(user);
            await _genericRepository.UpdateAsync(usertDataModel, _dataBaseContext);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _genericRepository.DeleteAsync(id, _dataBaseContext);
        }
    }

}
