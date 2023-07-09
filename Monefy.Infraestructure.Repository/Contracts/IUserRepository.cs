using Microsoft.EntityFrameworkCore;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Infraestructure.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User> ExistsUser(User user, DbContext context);
    }
}