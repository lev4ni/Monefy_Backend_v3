using Microsoft.EntityFrameworkCore;
using Monefy.Infraestructure.DataModels;
using Monefy.Infraestructure.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monefy.Infraestructure.Repository.repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<bool> ValidateUser(User user, DbContext context)
        {
            return await context.Set<User>().AnyAsync( u => (u.Name == user.Name || u.Email == user.Email) && u.Password == user.Password);
        }
    }
}
