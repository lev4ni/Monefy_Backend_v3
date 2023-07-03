using Monefy.Business.RepositoryContracts;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Domain.Implementation
{
    public class UserBusinessService : IUserBusinessService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserBusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<EntityUser>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            await _unitOfWork.SaveChangesAsync();
            return users;
        }
        public async Task<EntityUser> GetUserByIdAsync(Guid guid)
        {
            var usersGuid = await _unitOfWork.UserRepository.GetByIdAsync(guid);
            await _unitOfWork.SaveChangesAsync();
            return usersGuid;
        }
        public async Task CreateUserAsync(EntityUser user)
        {
            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateUserAsync(EntityUser user)
        {
            await _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteUserAsync(Guid id)
        {
            await _unitOfWork.UserRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
