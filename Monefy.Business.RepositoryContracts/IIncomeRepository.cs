﻿using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Business.RepositoryContracts
{
    public interface IIncomeRepository
    {
        Task<IEnumerable<EntityIncome>> GetAllAsync();
        Task<EntityIncome> GetByIdAsync(Guid id);
        Task AddAsync(EntityIncome income);
        Task UpdateAsync(EntityIncome income);
        Task DeleteAsync(Guid id );
    }
}
