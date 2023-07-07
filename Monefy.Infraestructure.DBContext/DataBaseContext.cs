
using Microsoft.EntityFrameworkCore;
using Monefy.Entities;
using Monefy.Infraestructure.DataModels;


namespace Monefy.Infraestructure.DBContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() { }
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Income { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Wallet> Wallet { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {       
            //optionsBuilder.UseSqlServer("DefaultConnection");
            optionsBuilder.UseSqlite("DatabaseLocation");
        }
        }
    }
}

