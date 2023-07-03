using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Infraestructure.DBContext
{
    public class CategoryContext : DbContext
    {
        public CategoryContext() { }
        public DbSet<CategoryDataModel> Category { get; set; }
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options) 
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries()
                .Where(e => e.Entity is CategoryDataModel 
                && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                var entity = (CategoryDataModel)entityEntry.Entity;

                if (entityEntry.State == EntityState.Added && entity.CreatedAt == default)
                {
                    entity.CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
