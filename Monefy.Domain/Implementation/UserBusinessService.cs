using FluentValidation;
using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Domain.Services;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
	public class UserBusinessService : IUserBusinessService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IUserRepository _userRepository;
		private readonly IWalletRepository _walletRepository;
		private readonly UserValidator _userValidator;
		public UserBusinessService(IUnitOfWork unitOfWork, IUserRepository userRepository, IWalletRepository walletRepository, UserValidator validator)
		{
			_unitOfWork = unitOfWork;
			_userRepository = userRepository;
			_walletRepository = walletRepository;
			_userValidator = validator;
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
            //var validationResult = _userValidator.Validate(user);

            //if (!validationResult.IsValid)
            //{
            //    var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
            //    // Puedes manejar los errores de validación de acuerdo a tus necesidades, lanzar una excepción, etc.
            //    throw new ValidationException("User validation failed", (IEnumerable<FluentValidation.Results.ValidationFailure>)errors);
            //}

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