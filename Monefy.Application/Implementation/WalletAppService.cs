using AutoMapper;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Domain.Contracts;
using Monefy.Entities;

namespace Monefy.Application.Implementation
{
    public class WalletAppService : IWalletAppService
    {
        private readonly IMapper _mapper;
        private readonly IWalletBusinessService _walletBusinessService;
        public WalletAppService(IMapper mapper, IWalletBusinessService walletBusinessService)
        {
            _mapper = mapper;
			_walletBusinessService = walletBusinessService;

        }

        public async Task CreateWalletAsync(WalletDTO walletDTO)
        {
            await _walletBusinessService.CreateWalletAsync(_mapper.Map<EntityWallet>(walletDTO));
        }

        public async Task DeleteWalletAsync(int id)

        {
            await _walletBusinessService.DeleteWalletAsync(id);
        }

        public async Task<IEnumerable<WalletDTO>> GetAllWalletsAsync()
        {
            var walletList = await _walletBusinessService.GetAllWalletsAsync();
            return _mapper.Map<IEnumerable<WalletDTO>>(walletList);
        }

        public async Task<WalletDTO> GetWalletByIdAsync(int id)

        {
            var wallet = await _walletBusinessService.GetWalletByIdAsync(id);
            return _mapper.Map<WalletDTO>(wallet);
        }

        public async Task UpdateWalletAsync(WalletDTO walletDTO)
        {
            await _walletBusinessService.UpdateWalletAsync(_mapper.Map<EntityWallet>(walletDTO));
        }
    }
}
