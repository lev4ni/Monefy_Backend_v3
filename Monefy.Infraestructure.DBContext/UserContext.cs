using Microsoft.EntityFrameworkCore;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Infraestructure.DBContext
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        public DbSet<UserDataModel> Users { get; set; }

       /* public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.Entity is UserDataModel
                && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                var entity = (UserDataModel)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added && entity.CreatedAt == default(DateTime))
                {
                    entity.CreatedAt = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }*/
    }
}
