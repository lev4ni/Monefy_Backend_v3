using Microsoft.EntityFrameworkCore;
using Monefy.Entities;

namespace Monefy.Business.RepositoryContracts
{
    public interface IUserRepository : IGenericRepository<EntityUser>
    {
        Task<EntityUser> ExistsUser(EntityUser entityUser);
        
    }
}
