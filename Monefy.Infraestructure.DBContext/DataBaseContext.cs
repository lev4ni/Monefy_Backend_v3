
using Microsoft.EntityFrameworkCore;
using Monefy.Infraestructure.DataModels;


namespace Monefy.Infraestructure.DBContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() { }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<CategoryDataModel> Category { get; set; }
        public DbSet<CurrencyDataModel> Currency { get; set; }
        public DbSet<ExpenseDataModel> Expenses { get; set; }
        public DbSet<IncomeDataModel> Income { get; set; }
        public DbSet<UserDataModel> User { get; set; }
        public DbSet<WalletDataModel> Wallet { get; set; }hhhh

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }
    }
}

