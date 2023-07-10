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

        public async Task<UserDTO> CreateUserAsync(UserDTO userDTO)
        {
            await _userBusinessService.CreateUserAsync(_mapper.Map<EntityUser>(userDTO));
            return userDTO;
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

        public async Task<UserDTO> ExistsUser(UserDTO userDTO)
        {
            var user = await _userBusinessService.ExistsUser(_mapper.Map<EntityUser>(userDTO));
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUseryAsync(UserDTO userDTO)
        {
            await _userBusinessService.UpdateUserAsync(_mapper.Map<EntityUser>(userDTO));
            return userDTO;
        }
        public async Task<UserDTO> DeleteUserAsync(int id)
        {
            await _userBusinessService.DeleteUserAsync(id);
            return _mapper.Map<UserDTO>(id);
        }
    }
  }
