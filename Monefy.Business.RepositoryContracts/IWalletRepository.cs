using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Business.RepositoryContracts
{
    public interface IWalletRepository
    {
        Task<IEnumerable<EntityWallet>> GetAllAsync();
        Task<EntityWallet> GetByIdAsync(Guid id);
        Task AddAsync(EntityWallet wallet);
        Task UpdateAsync(EntityWallet wallet);
        Task DeleteAsync(Guid id);
    }
}
