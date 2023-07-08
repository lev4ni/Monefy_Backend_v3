using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.Contracts;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class UserInfraestrucutureService : IUserInfraestrucutureService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<User> _genericRepository;
        private readonly DataBaseContext _dataBaseContext;

        public UserInfraestrucutureService(IMapper mapper, IGenericRepository<User> genericRepository, DataBaseContext context)
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

        public async Task<EntityUser> GetByIdAsync(int id)
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
            var userDataModel = _mapper.Map<User>(user);
            await _genericRepository.UpdateAsync(userDataModel, _dataBaseContext);
        }

        public async Task DeleteAsync(int id)
        {
            await _genericRepository.DeleteAsync(id, _dataBaseContext);
        }
    }

}
