using Microsoft.EntityFrameworkCore;
using Monefy.Infraestructure.DataModels;


namespace Monefy.Infraestructure.DBContext
{
    public class WalletContext : DbContext
    {
        public WalletContext(DbContextOptions<WalletContext> options) : base(options) { }
        public DbSet<WalletDataModel> Wallet { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.Entity is WalletDataModel
                && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                var entity = (WalletDataModel)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added && entity.CreatedAt == default(DateTime))
                {
                    entity.CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
