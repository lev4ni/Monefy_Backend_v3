using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Business.RepositoryContracts
{
    public interface ICurrencyInfraestrucutureService
    {
        Task<IEnumerable<EntityCurrency>> GetAllAsync();
        Task<EntityCurrency> GetByIdAsync(int id);
        Task AddAsync(EntityCurrency currency);
        Task UpdateAsync(EntityCurrency currency);
        Task DeleteAsync(int id);

    }
}
