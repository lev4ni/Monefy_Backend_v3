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
        public async Task<User> ExistsUser(User user, DbContext context)
        {
            var userDB = await context.Set<User>().FirstOrDefaultAsync( u => (u.Name == user.Name || u.Email == user.Email));
            if (userDB == null) throw new ArgumentException();
            else return userDB;
        }
    }
}
