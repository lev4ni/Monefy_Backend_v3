using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Business.RepositoryContracts
{
    public interface IExpenseRepository : IGenericRepository<EntityExpense>
    {
        Task<IEnumerable<EntityExpense>> GetWalletExpensesAsync(int walletId);

    }
}
