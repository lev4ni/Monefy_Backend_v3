using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.services;
using System.Security.Cryptography.X509Certificates;

namespace Monefy.Infraestructure.Repository.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly DataBaseContext _dataBaseContext;

        public UserRepository(IMapper mapper, DataBaseContext context) : base(context)
        {
            _mapper = mapper;
            _dataBaseContext = context;
        }

        public new async Task<IEnumerable<EntityUser>> GetAllAsync()
        {
            var userDataModels = await base.GetAllAsync();
            return _mapper.Map<IEnumerable<EntityUser>>(userDataModels);
        }

        public new async Task<EntityUser> GetByIdAsync(int id)
        {
            var userDataModel = await base.GetByIdAsync(id);
            return _mapper.Map<EntityUser>(userDataModel);
        }

        public async Task AddAsync(EntityUser user)
        {
            var userDataModel = _mapper.Map<User>(user);
            await base.AddAsync(userDataModel);
        }

        public async Task UpdateAsync(EntityUser user)
        {
            var userDataModel = _mapper.Map<User>(user);
            await base.UpdateAsync(userDataModel);
        }

        public async Task<EntityUser> ExistsUser(EntityUser entityUser)
        {
            var user = _mapper.Map<User>(entityUser);
            var userDB = await _dataBaseContext.Set<User>().FirstOrDefaultAsync(u => (u.Name == user.Name || u.Email == user.Email));
            if (userDB == null) throw new ArgumentException();
            return _mapper.Map<EntityUser>(userDB);
        }
    }

}
