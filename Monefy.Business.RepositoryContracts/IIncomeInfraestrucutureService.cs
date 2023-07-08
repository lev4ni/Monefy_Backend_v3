using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Business.RepositoryContracts
{
    public interface IIncomeInfraestrucutureService
    {
        Task<IEnumerable<EntityIncome>> GetAllAsync();
        Task<EntityIncome> GetByIdAsync(int id);
        Task AddAsync(EntityIncome income);
        Task UpdateAsync(EntityIncome income);
        Task DeleteAsync(int id );
    }
}
