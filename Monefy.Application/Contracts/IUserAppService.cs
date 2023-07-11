using Monefy.Application.DTOs;

namespace Monefy.Application.Contracts
{
    public interface IUserAppService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<UserDTO> CreateUserAsync(UserDTO UserDTO);
        Task<UserDTO> UpdateUseryAsync(UserDTO UserDTO);
        Task<UserDTO> DeleteUserAsync(int id);
        Task<UserDTO> ExistsUser(UserDTO userDTO);
        Task<IEnumerable<WalletDTO>> GetUserWallets(int id);
    }
}
