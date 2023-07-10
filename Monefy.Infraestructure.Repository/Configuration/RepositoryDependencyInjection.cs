using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Monefy.Business.RepositoryContracts;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.Implementations;
using Monefy.Infraestructure.Repository.services;

namespace Monefy.Infraestructure.Repository.Configuration
{
    public static class RepositoryDependencyInjection

    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(CategoryRepository));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<ICategoryRepository, CategoryRepository>();

            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWalletRepository, WalletRepository>();
            services.AddTransient<IIncomeRepository, IncomeRepository>();

            services.AddTransient<IIncomeRepository, IncomeRepository>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();

            services.AddDbContext<DataBaseContext>(
                options =>
                {
                    options.UseSqlServer(connectionString).LogTo(Console.WriteLine);
                });

            return services;
        }
    }
}
