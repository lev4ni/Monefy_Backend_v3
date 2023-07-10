using Microsoft.Extensions.DependencyInjection;
using Monefy.Infraestructure.DBContext;
using Monefy.Infraestructure.Repository.Implementations;
using Microsoft.EntityFrameworkCore;
using Monefy.Business.RepositoryContracts;
using Monefy.Infraestructure.Repository.Contracts;
using Monefy.Infraestructure.Repository.repositories;


namespace Monefy.Infraestructure.Repository.Configuration
{
    public static class RepositoryDependencyInjection

    {
       public static IServiceCollection AddInfraestructure(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper(typeof(CategoryInfraestrucutureService));

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<ICategoryInfraestrucutureService, CategoryInfraestrucutureService>();

            services.AddTransient<ICurrencyInfraestrucutureService, CurrencyInfraestrucutureService>();
            services.AddTransient<IExpenseInfraestrucutureService, ExpenseInfraestrucutureService>();
            services.AddTransient<IUserInfraestrucutureService, UserInfraestrucutureService>();
            services.AddTransient<IWalletInfraestrucutureService, WalletInfraestrucutureService>();
            services.AddTransient<IIncomeInfraestrucutureService, IncomeInfraestrucutureService>();

            services.AddTransient<IIncomeInfraestrucutureService, IncomeInfraestrucutureService>();
            services.AddTransient<IExpenseInfraestrucutureService, ExpenseInfraestrucutureService>();

            services.AddDbContext<DataBaseContext>(
                options =>
                {
                    options.UseSqlServer(connectionString).LogTo(Console.WriteLine);
                });

            return services;
        }
    }
}
