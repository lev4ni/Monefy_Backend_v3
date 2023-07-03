using Microsoft.EntityFrameworkCore;
using Monefy.Infraestructure.DataModels;

namespace Monefy.Infraestructure.DBContext
{
    public class CurrencyContext : DbContext
    {
        public CurrencyContext() { }
        public CurrencyContext(DbContextOptions<CurrencyContext> options) : base(options) { }
        public DbSet<CurrencyDataModel> Currency { get; set; }

      
    }
}


