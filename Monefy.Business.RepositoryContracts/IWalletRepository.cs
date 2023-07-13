using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Business.RepositoryContracts
{
    public interface IWalletRepository : IGenericRepository<EntityWallet>
    {
        Task<IEnumerable<EntityWallet>> GetUserWalletsAsync(int id);
        Task<EntityWallet> getWalletByUserAndName(int id, string name);
    }
}
