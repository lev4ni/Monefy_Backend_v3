using AutoMapper;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DBContext;


namespace Monefy.Infraestructure.Repository.Implementations
{
    public class UserRepository : GenericRepository<EntityUser>, IUserRepository
    {
        private readonly IMapper _mapper;

        public UserRepository(DataBaseContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntityUser>> GetAllAsync()
        {
            var userDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityUser>>(userDataModels);
        }

        public async Task<EntityUser> GetByIdAsync(Guid id)
        {
            var userDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<EntityUser>(userDataModel);
        }

        public async Task AddAsync(EntityUser user)
        {
            var userDataModel = _mapper.Map<EntityUser>(user);
            await base.AddAsync(userDataModel);
        }

        public async Task UpdateAsync(EntityUser user)
        {
            var usertDataModel = _mapper.Map<EntityUser>(user);
            await base.UpdateAsync(usertDataModel);
        }

        public async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
        }
    }

}
