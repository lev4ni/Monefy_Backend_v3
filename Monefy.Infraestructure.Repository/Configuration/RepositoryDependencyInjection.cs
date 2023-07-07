using Microsoft.Extensions.DependencyInjection;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;
using Monefy.Infraestructure.Repository.Contracts;

namespace Monefy.Infraestructure.Repository.Configuration
{
    public static class RepositoryDependencyInjection

    {
       public static IServiceCollection AddInfraestructure(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //services.AddAutoMapper(typeof(LiteDbCategoryRepository));
            services.AddAutoMapper(typeof(CategoryInfraestrucutureService));
            services.AddAutoMapper(typeof(CurrencyInfraestrucutureService));
            services.AddAutoMapper(typeof(ExpenseInfraestrucutureService));
            services.AddAutoMapper(typeof(UserInfraestrucutureService));
            services.AddAutoMapper(typeof(WalletInfraestrucutureService));
            services.AddAutoMapper(typeof(IncomeInfraestrucutureService));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICategoryInfraestrucutureService, CategoryInfraestrucutureService>();

            services.AddTransient<ICurrencyInfraestrucutureService, CurrencyInfraestrucutureService>();
            services.AddTransient<IExpenseInfraestrucutureService, ExpenseInfraestrucutureService>();
            services.AddTransient<IUserInfraestrucutureService, UserInfraestrucutureService>();
            services.AddTransient<IWalletInfraestrucutureService, WalletInfraestrucutureService>();
            services.AddTransient<IIncomeInfraestrucutureService, IncomeInfraestrucutureService>();

            services.AddDbContext<DataBaseContext>(
                options =>
                {
                    options.UseSqlServer(connectionString);
                });

            return services;
        }
    }
}
