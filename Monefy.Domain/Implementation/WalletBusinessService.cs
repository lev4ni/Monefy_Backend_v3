using Monefy.Domain.Contracts;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Domain.Implementation
{
    public class WalletBusinessService : IWalletBusinessService
    {
        public Task CreateWalletAsync(EntityWallet wallet)
        {
            throw new NotImplementedException();
        }

        public Task DeleteWalletAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EntityWallet>> GetAllWalletsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<EntityWallet> GetWalletByIdAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task UpdateWalletAsync(EntityWallet wallet)
        {
            throw new NotImplementedException();
        }
    }
}
