using Monefy.Application.DTOs;

namespace Monefy.Application.Contracts
{
    public interface IUserAppService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(Guid id);
        Task CreateUserAsync(UserDTO UserDTO);
        Task UpdateUseryAsync(UserDTO UserDTO);
        Task DeleteUserAsync(Guid id);
    }
}
