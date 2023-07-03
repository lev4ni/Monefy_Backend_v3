using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(CategoryContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var userDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<User>>(userDataModels);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var userDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<User>(userDataModel);
        }

        public async Task AddAsync(User user)
        {
            var userDataModel = _mapper.Map<User>(user);
            await base.AddAsync(userDataModel);
        }

        public async Task UpdateAsync(User user)
        {
            var usertDataModel = _mapper.Map<User>(user);
            await base.UpdateAsync(usertDataModel);
        }

        public async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }

}
