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
        Task<IEnumerable<Wallet>> GetAllAsync();
        Task<Wallet> GetByIdAsync(Guid id);
        Task AddAsync(Wallet wallet);
        Task UpdateAsync(Wallet wallet);
        Task DeleteAsync(Guid id);
    }
}
