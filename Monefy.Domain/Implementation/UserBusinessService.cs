using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
	public class UserBusinessService : IUserBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserInfraestrucutureService _userInfraestrucutureService;
		public UserBusinessService(IUnitOfWork unitOfWork, IUserInfraestrucutureService userInfraestrucutureService)
		{
			_unitOfWork = unitOfWork;
			_userInfraestrucutureService = userInfraestrucutureService;

		}
		public async Task<IEnumerable<EntityUser>> GetAllUsersAsync()
		{
			var users = await _userInfraestrucutureService.GetAllAsync();
			return users;
		}
		public async Task<EntityUser> GetUserByIdAsync(int id)
		{
			var usersGuid = await _userInfraestrucutureService.GetByIdAsync(id);
			return usersGuid;
		}
		public async Task CreateUserAsync(EntityUser user)
		{
			await _userInfraestrucutureService.AddAsync(user);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task UpdateUserAsync(EntityUser user)
		{
			await _userInfraestrucutureService.UpdateAsync(user);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteUserAsync(int id)
		{
			await _userInfraestrucutureService.DeleteAsync(id);
			await _unitOfWork.SaveChangesAsync();
		}

        public async Task<EntityUser> GetUserByNameAsync(string name)
        {
            return await _userInfraestrucutureService.GetUserByNameAsync(name);
        }

        public async Task RegisterUserAsync(EntityUser user)
        {
            var existingUser = await _userInfraestrucutureService.GetUserByNameAsync(user.Name);
            if (existingUser != null)
            {
                throw new Exception("User with the same name already exists.");
            }

            // Implementar la lógica para registrar un nuevo usuario en _userInfraestrucutureService
            await _userInfraestrucutureService.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<EntityUser?> AuthenticateUserAsync(string name, string password)
        {
            var user = await _userInfraestrucutureService.GetUserByNameAsync(name);

            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }

    }
}