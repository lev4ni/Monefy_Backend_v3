using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Business.RepositoryContracts
{
    public interface IIncomeRepository : IGenericRepository<EntityIncome>
    {
        Task<IEnumerable<EntityIncome>> GetWalletIncomesAsync(int walletId, DateTime initialDate, DateTime finalDate);

    }
}
