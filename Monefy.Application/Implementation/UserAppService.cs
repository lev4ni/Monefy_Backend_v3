using AutoMapper;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Application.Implementation
{
    public class UserAppService : IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserBusinessService _userBusinessService;
        public UserAppService(IMapper mapper, IUserBusinessService userBusinessService)
        {
            _mapper = mapper;
			_userBusinessService = userBusinessService;

        }

        public async Task CreateUserAsync(UserDTO userDTO)
        {
            await _userBusinessService.CreateUserAsync(_mapper.Map<EntityUser>(userDTO));
        }

        public async Task DeleteUserAsync(int id)

        {
            await _userBusinessService.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var userList = await _userBusinessService.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(userList);
        }

        public async Task<UserDTO> GetUserByIdAsync(int id)

        {
            var user = await _userBusinessService.GetUserByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task UpdateUseryAsync(UserDTO userDTO)
        {
            await _userBusinessService.UpdateUserAsync(_mapper.Map<EntityUser>(userDTO));
        }

        public async Task<bool> ValidateUser(UserDTO userDTO)
        {
            return await _userBusinessService.ValidateUser(_mapper.Map<EntityUser>(userDTO));
        }
    }
}
