using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
	public class UserBusinessService : IUserBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRepository _userRepository;
		private readonly IWalletRepository _walletRepository;
		public UserBusinessService(IUnitOfWork unitOfWork, IUserRepository userRepository, IWalletRepository walletRepository)
		{
			_unitOfWork = unitOfWork;
			_userRepository = userRepository;
			_walletRepository = walletRepository;
		}
		public async Task<IEnumerable<EntityUser>> GetAllUsersAsync()
		{
			var users = await _userRepository.GetAllAsync();
			return users;
		}
		public async Task<EntityUser> GetUserByIdAsync(int id)
		{
			var usersGuid = await _userRepository.GetByIdAsync(id);
			return usersGuid;
		}
		public async Task CreateUserAsync(EntityUser user)
		{
			await _userRepository.AddAsync(user);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task UpdateUserAsync(EntityUser user)
		{
			await _userRepository.UpdateAsync(user);
			await _unitOfWork.SaveChangesAsync();
		}
		public async Task DeleteUserAsync(int id)
		{
			await _userRepository.DeleteAsync(id);
			await _unitOfWork.SaveChangesAsync();
		}

        public async Task<EntityUser> ExistsUser(EntityUser entityUser)
        {
			return await _userRepository.ExistsUser(entityUser);
        }

        public async Task<IEnumerable<EntityWallet>> GetUserWallets(int id)
        {
			var wallets = await _walletRepository.GetUserWalletsAsync(id);
            return wallets;
        }
    }
}