using Microsoft.EntityFrameworkCore;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Infraestructure.DBContext
{
    public class IncomeContext : DbContext
    {
        public IncomeContext(DbContextOptions<IncomeContext> options) : base(options) { }
        public DbSet<IncomeDataModel> Incomes { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.Entity is IncomeDataModel
                && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                var entity = (IncomeDataModel)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added && entity.CreatedAt == default(DateTime))
                {
                    entity.CreatedAt = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
