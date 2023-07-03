using Monefy.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Application.Contracts
{
    public interface IWalletAppService
    {
        Task<IEnumerable<WalletDTO>> GetAllWalletsAsync();
        Task<WalletDTO> GetWalletByIdAsync(Guid id);
        Task CreateWalletAsync(WalletDTO walletDTO);
        Task UpdateWalletAsync(WalletDTO walletDTO);
        Task DeleteWalletAsync(Guid id);
    }
}
