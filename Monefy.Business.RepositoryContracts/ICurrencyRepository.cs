using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Business.RepositoryContracts
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetAllAsync();
        Task<Currency> GetByIdAsync(Guid id);
        Task AddAsync(Currency currency);
        Task UpdateAsync(Currency currency);
        Task DeleteAsync(Guid id);
    }
}
