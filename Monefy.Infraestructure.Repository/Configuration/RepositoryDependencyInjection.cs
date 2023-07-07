using Microsoft.Extensions.DependencyInjection;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;


namespace Monefy.Infraestructure.Repository.Configuration
{
    public static class RepositoryDependencyInjection

    {
       public static IServiceCollection AddInfraestructure(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //services.AddAutoMapper(typeof(LiteDbCategoryRepository));
            services.AddAutoMapper(typeof(CategoryRepository));
            services.AddAutoMapper(typeof(CurrencyRepository));
            services.AddAutoMapper(typeof(ExpenseRepository));
            services.AddAutoMapper(typeof(UserRepository));
            services.AddAutoMapper(typeof(WalletRepository));
            services.AddAutoMapper(typeof(IncomeRepository));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            //services.AddTransient<ICategoryRepository, LiteDbCategoryRepository>();

            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IWalletRepository, WalletRepository>();
            services.AddTransient<IIncomeRepository, IncomeRepository>();

            services.AddDbContext<DataBaseContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                });

            return services;
        }
    }
}
