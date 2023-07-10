using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Business.RepositoryContracts
{
    public interface IWalletInfraestrucutureService
    {
        Task<IEnumerable<EntityWallet>> GetAllAsync();
        Task<EntityWallet> GetByIdAsync(int id);
        Task AddAsync(EntityWallet wallet);
        Task UpdateAsync(EntityWallet wallet);
        Task DeleteAsync(int id);
        Task<IEnumerable<EntityWallet>> GetUsersWalletAsync(int id);

    }
}
