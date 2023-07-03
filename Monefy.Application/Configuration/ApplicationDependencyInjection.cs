
using Microsoft.Extensions.DependencyInjection;
using Monefy.Application.Contracts;
using Monefy.Application.Implementation;
using Monefy.Domain.Configuration;
using Monefy.Infraestructure.Repository.Configuration;

namespace Monefy.Application.Configuration
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICategoryAppService, CategoryAppService>();
            services.AddTransient<ICurrencyAppService, CurrencyAppService>();
            services.AddTransient<IExpenseAppService, ExpenseAppService>();
            services.AddTransient<IUserAppService, UserAppService>();
            services.AddTransient<IWalletAppService, WalletAppService>();
            services.AddTransient<IIncomeAppService, IncomeAppService>();

            services.AddAutoMapper(typeof(CategoryAppService));
            services.AddAutoMapper(typeof(CurrencyAppService));
            services.AddAutoMapper(typeof(ExpenseAppService));
            services.AddAutoMapper(typeof(UserAppService));
            services.AddAutoMapper(typeof(WalletAppService));
            services.AddAutoMapper(typeof(IncomeAppService));

            services.AddBusiness(connectionString);
            services.AddInfraestructure(connectionString);

            return services;
        }
    }
}
