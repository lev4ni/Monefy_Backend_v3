using Microsoft.EntityFrameworkCore;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Infraestructure.DBContext
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options) { }
        public DbSet<ExpenseDataModel> Expenses { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.Entity is ExpenseDataModel
                && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                var entity = (ExpenseDataModel)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added && entity.CreatedAt == default(DateTime))
                {
                    entity.CreatedAt = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

